using System;
using System.Collections.Generic;
using System.Threading;

public class ReflectingActivity : Activity
{
    public List<string> _prompt;
    public List<string> _question;

    public ReflectingActivity()
    {
        _name = "Reflecting Activity";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
        _duration = 0;
        _prompt = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };
        _question = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
    }

    public void Run()
    {
        DisplayStartingMessage();

        int remainingDuration = _duration; // Track remaining duration separately

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime && remainingDuration > 0)
        {
            string prompt = GetRandomPrompt();
            Console.WriteLine("Consider the following prompt:");
            Console.WriteLine("");
            DisplayPrompt(prompt);
            remainingDuration -= 5; // Reduce remaining duration for prompt and pause
            Console.WriteLine("");
            Console.WriteLine("When you have something in mind, press Enter to continue");
            Console.ReadLine(); // Wait for the user to press Enter

            Console.Clear();
            Console.WriteLine("Now ponder on each of the following questions as they relate to this experience");
            Console.WriteLine("You may begin in...");
            ShowCountDown(5);
            remainingDuration -= 5;
            Console.Clear();

            // Display questions until duration runs out
            while (DateTime.Now < endTime && remainingDuration > 0)
            {
                string question = GetRandomQuestion();
                DisplayQuestion(question);
                ShowSpinner(8);
                remainingDuration -= 8; // Reduce remaining duration for question and pause
            }
        }

        DisplayEndingMessage();
    }


    public string GetRandomPrompt()
    {
        Random random = new Random();
        int randomIndex = random.Next(_prompt.Count);
        return _prompt[randomIndex];
    }

    public string GetRandomQuestion()
    {
        Random random = new Random();
        int randomIndex = random.Next(_question.Count);
        return _question[randomIndex];
    }

    public void DisplayPrompt(string prompt)
    {
        Console.WriteLine($"---{prompt}---");
    }

    public void DisplayQuestion(string question)
    {
        Console.WriteLine($"> {question}");
    }
}
