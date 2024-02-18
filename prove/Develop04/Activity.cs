using System.ComponentModel.DataAnnotations;

public class Activity{

    protected string _name;
    protected string _description;

    protected int _duration;

    public Activity(){
        
    }
    
    protected void DisplayStartingMessage(){

        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine("");
        Console.WriteLine($"{_description}");
        Console.WriteLine("");
        Console.WriteLine($"How long in seconds would you like for this session: ");
        if (!int.TryParse(Console.ReadLine(), out _duration) || _duration <= 0)
        {
            Console.WriteLine("Invalid input. Please enter a valid duration in seconds.");
            return;
        }
        Console.Clear();
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3); // Pause for 3 seconds
    }

    protected void DisplayEndingMessage(){

        Console.WriteLine($"Ending {_name}");
        Console.WriteLine($"You've done a good job!");
        Console.WriteLine($"You completed {_name} for {_duration} seconds.");
        ShowSpinner(3); // Pause for 3 seconds
    }

    protected void ShowSpinner(int seconds){

        List<string> animation = new List<string>();
        animation.Add("|");
        animation.Add("/");
        animation.Add("—");
        animation.Add("\\");
        animation.Add("|");
        animation.Add("/");
        animation.Add("—");
        animation.Add("\\");



        foreach (string a in animation)
        {

            Console.Write(a);
            Thread.Sleep(1000);
            Console.Write("\b \b"); // Erase the + character

            // Pause for 1 second
        }
        Console.WriteLine();
    }

    protected void ShowCountDown(int seconds){

        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i}");
            Thread.Sleep(1000); // Pause for 1 second
            Console.Write("\b \b");
        }
    }
}
