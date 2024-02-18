using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    public int _count;
    public List<string> _prompts;

    public ListingActivity()
    {
        _name = "Listing Activity";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
        _duration = 0; // Default duration
        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };
        _count = 0; // Initialize count to 0
    }

    public void Run()
    {
        DisplayStartingMessage();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (_count < _prompts.Count && DateTime.Now < endTime)
        {
            string prompt = _prompts[_count];
            Console.WriteLine("List as many responses as you can to the following prompt:");
            Console.WriteLine($"---{prompt}---");
            ShowSpinner(3); // Pause for 3 seconds
            List<string> listItems = GetListFromUser();
            Console.WriteLine($"You listed {listItems.Count} items.");

            _count++; // Increment count

            // Check if count has reached the maximum number of prompts or the time has elapsed
            if (_count >= _prompts.Count || DateTime.Now >= endTime)
            {
                break; // Exit the loop if all prompts have been displayed or time has elapsed
            }
        }

        DisplayEndingMessage();
    }

    public List<string> GetListFromUser()
    {
        Console.WriteLine("Enter as many items as you can related to the prompt (press Enter after each item, type 'done' when finished):");
        string item;

        List<string> listItems = new List<string>();
        do
        {
            item = Console.ReadLine();
            if (item.ToLower() != "done")
            {
                listItems.Add(item);
            }
        } while (item.ToLower() != "done");

        return listItems;
    }
}
