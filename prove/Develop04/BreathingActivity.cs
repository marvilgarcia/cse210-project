using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing Activity";
        _description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
        _duration = 0; // duration added by the user
    }

    public void Run()
    {
        DisplayStartingMessage();

        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < futureTime)
        {
            Console.Write("Breathe in...");
            ShowCountDown(3);
            Console.WriteLine("");
            Console.Write("Breathe out...");
            ShowCountDown(3);
            Console.WriteLine("");
            Console.WriteLine("");

            // Check if the current time has passed the future time
            if (DateTime.Now >= futureTime)
            {
                break; // Exit the loop if duration has been reached
            }
        }

        DisplayEndingMessage();
    }
}