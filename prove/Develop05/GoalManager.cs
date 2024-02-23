using System.Globalization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;


public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score;

    public void Start()
    {
        while (true)
        {
            DisplayPlayerInfo();
            Console.WriteLine("");
            Console.WriteLine("Menu options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");

            Console.Write("Select a choice from the menu: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        CreateGoal();
                        break;
                    case 2:
                        ListGoalDetails();
                        break;
                    case 3:
                        Console.Write("Enter the file name to save goals from: ");
                        string fileName = Console.ReadLine();
                        SaveGoals(fileName);
                        break;
                    case 4:
                        Console.Write("Enter the file name to load goals from: ");
                        string file = Console.ReadLine();
                        LoadGoals(file);
                        break;
                    case 5:
                        RecordEvent();
                        break;
                    case 6:
                        Environment.Exit(0); // Exit the application
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }

    private void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have: {_score} points");
        Console.WriteLine("");
    }

    private void ListGoalDetails()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            var goal = _goals[i];
            string completionStatus = goal.IsComplete() ? "[X]" : "[ ]";
            string progress = "";

            if (goal is ChecklistGoal checklistGoal)
            {
                progress = $"-- Completed {checklistGoal._amountComplete}/{checklistGoal._target} times";
            }
            else if (goal is TimedGoal timedGoal)
            {
                progress = $"-- Remaining Time: {timedGoal.GetFormattedRemainingTime()}";
            }

            Console.WriteLine($"{i + 1}. {completionStatus} {goal._shortName} ({goal._description}) {progress}");
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("");
        Console.WriteLine("The types of goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. CheckList Goal");
        Console.WriteLine("4. Timed Goal");
        Console.Write("Which type of goal would you like to create? ");

        if (int.TryParse(Console.ReadLine(), out int choice))
        {
            Console.Write("Enter the name of the goal: ");
            string name = Console.ReadLine();
            Console.Write("Enter the description of the goal: ");
            string description = Console.ReadLine();
            Console.Write("Enter the points of the goal: ");
            string points = Console.ReadLine();

            switch (choice)
            {
                case 1:
                    _goals.Add(new SimpleGoal(name, description, points));
                    break;
                case 2:
                    _goals.Add(new EternalGoal(name, description, points));
                    break;
                case 3:
                    Console.Write("How many times does this goal need to be accomplished for a bonus?: ");
                    if (int.TryParse(Console.ReadLine(), out int target))
                    {
                        Console.Write("What is the bonus for accomplishing it that many times?: ");
                        if (int.TryParse(Console.ReadLine(), out int bonus))
                        {
                            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                        }
                        else
                        {
                            Console.WriteLine("Invalid bonus amount. Goal creation failed.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid target amount. Goal creation failed.");
                    }
                    break;
                case 4:
                    Console.Write("Enter the expected time to accomplish the goal (e.g., '5 hours'): ");
                    string expectedTimeInput = Console.ReadLine();

                    if (TimedGoal.ParseExpectedTime(expectedTimeInput, out TimeSpan expectedTime))
                    {
                        _goals.Add(new TimedGoal(name, description, points, expectedTime,expectedTime));
                    }
                    else
                    {
                        Console.WriteLine("Invalid expected time format. Goal creation failed.");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid choice. Goal creation failed.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }
    }

    private void RecordEvent()
    {
        Console.Write("Which goal did you accomplish?: ");
        if (int.TryParse(Console.ReadLine(), out int goalNumber))
        {
            if (goalNumber > 0 && goalNumber <= _goals.Count)
            {
                Goal goal = _goals[goalNumber - 1];
                goal.RecordEvent();
                _score += int.Parse(goal._points); // Increase score based on the goal's points
                if (goal is ChecklistGoal checklistGoal)
                    {   
                        if (checklistGoal.IsComplete() == true ){
                            _score += checklistGoal._bonus;
                            }
                    } 
                else if (goal is TimedGoal timedGoal)
                {
                    // Verificar si el objetivo se ha completado antes de que el tiempo haya transcurrido por completo
                    if (timedGoal.IsComplete())
                    {
                        // Marcar el objetivo como completado y detener el tiempo restante
                        timedGoal.RecordEvent();
                        timedGoal._remainingTime = TimeSpan.Zero;
                    }
                    else
                    {
                        // Calcular el tiempo transcurrido desde que se creó la meta
                        TimeSpan elapsedTime = DateTime.Now - timedGoal._createdAt;
                        // Calcular el tiempo restante
                        TimeSpan remainingTime = timedGoal._expectedTime - elapsedTime;

                        // Actualizar el tiempo restante en el objetivo
                        timedGoal._remainingTime = remainingTime;
                    }
                }

                Console.WriteLine($"Congratulations! You have completed the {goal._shortName} and earned {goal._points} points");
            }
            else
            {
                Console.WriteLine("Invalid goal number. Please enter a valid goal number.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid integer.");
        }
    }




    public void SaveGoals(string fileName)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                // Save the score
                writer.WriteLine(_score);

                // Save the goals
                foreach (var goal in _goals)
                {
                    string goalType = goal.GetType().Name;
                    string goalInfo = $"{goalType}:{goal._shortName},{goal._description},{goal._points},{goal.IsComplete()}";

                    if (goal is ChecklistGoal checklistGoal)
                    {
                        goalInfo += $",{checklistGoal._target},{checklistGoal._bonus}";
                    }
                    else if (goal is TimedGoal timedGoal)
                    {
                        goalInfo += $",{timedGoal._expectedTime},{timedGoal._remainingTime}";
                    }

                    writer.WriteLine(goalInfo);
                }
            }

            Console.WriteLine("Goals saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving goals: {ex.Message}");
        }
    }
    public void LoadGoals(string fileName)
    {
        try
        {
            if (!File.Exists(fileName))
            {
                Console.WriteLine("Goals file not found.");
                return;
            }

            using (StreamReader reader = new StreamReader(fileName))
            {
                // Load the score
                if (int.TryParse(reader.ReadLine(), out int score))
                {
                    _score = score;
                }
                else
                {
                    Console.WriteLine("Invalid score format. Loading goals without score.");
                }

                // Clear existing goals before loading
                _goals.Clear();

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(':');
                    if (parts.Length < 2)
                    {
                        Console.WriteLine($"Invalid goal format: {line}");
                        continue;
                    }

                    string goalType = parts[0].Trim();
                    string[] values = parts[1].Split(',');

                    if (values.Length < 4)
                    {
                        Console.WriteLine($"Invalid goal format: {line}");
                        continue;
                    }

                    string name = values[0].Trim();
                    string description = values[1].Trim();
                    string points = values[2].Trim();
                    bool isComplete = bool.Parse(values[3].Trim());

                    switch (goalType)
                    {
                        case "SimpleGoal":
                            _goals.Add(new SimpleGoal(name, description, points));
                            break;
                        case "EternalGoal":
                            _goals.Add(new EternalGoal(name, description, points));
                            break;
                        case "ChecklistGoal":
                            if (values.Length < 6)
                            {
                                Console.WriteLine($"Invalid goal format: {line}");
                                continue;
                            }
                            int target = int.Parse(values[4].Trim());
                            int bonus = int.Parse(values[5].Trim());
                            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                            break;
                        case "TimedGoal":
                            if (values.Length < 6)
                            {
                                Console.WriteLine($"Invalid goal format: {line}");
                                continue;
                            }
                            TimeSpan expectedTime;
                            if (!TimeSpan.TryParseExact(values[4].Trim(), @"hh\:mm\:ss", CultureInfo.InvariantCulture, out expectedTime))
                            {
                                Console.WriteLine($"Invalid expected time format: {values[4].Trim()}");
                                continue;
                            }
                            TimeSpan remainingTime;
                            if (!TimeSpan.TryParseExact(values[5].Trim(), @"hh\:mm\:ss", CultureInfo.InvariantCulture, out remainingTime))
                            {
                                Console.WriteLine($"Invalid remaining time format: {values[5].Trim()}");
                                continue;
                            }
                            _goals.Add(new TimedGoal(name, description, points, expectedTime, remainingTime));
                            break;
                        default:
                            Console.WriteLine($"Unknown goal type: {goalType}");
                            break;
                    }
                }
            }

            Console.WriteLine("Goals loaded successfully.");
        }
        catch (Exception ex)
    {
            Console.WriteLine($"Error loading goals: {ex.Message}");
        }
    }
}

