using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();

        Console.WriteLine("Welcome to the journal program");
        Console.WriteLine("Please select one of the following choices:");
        Console.WriteLine("1. Write");
        Console.WriteLine("2. Display");
        Console.WriteLine("3. Load");
        Console.WriteLine("4. Save");
        Console.WriteLine("5. Exit");
        Console.Write("What do you want to do?: ");

        string response = Console.ReadLine();

        while (response != "5")
        {
            if (response == "1")
            {
                PromptGenerator myPrompt = new PromptGenerator();
                myPrompt._prompts = new List<string>
                {
                    "What was the best part of my day?",
                    "How did I see the hand of the Lord in my life today?",
                    "What was the strongest emotion I felt today?",
                    "If I had one thing I could do over today, what would it be?"
                };

                string randomPrompt = myPrompt.GetRandomPrompt();
                Console.WriteLine($"{randomPrompt}");
                string entryText = Console.ReadLine();

                // Create an Entry object and add it to the journal
                Entry newEntry = new Entry();
                newEntry._promptText = randomPrompt;
                newEntry._entryText = entryText;
                journal.AddEntry(newEntry);
            }
            else if (response == "2")
            {
                // Display existing entries from the journal
                Entry entry = new Entry();
                journal.DisplayAll();
            }
            else if (response == "3")
            {
                Console.Write("Enter the file name to load: ");
                string file = Console.ReadLine();
                // Assuming Journal has a LoadFromFile method
                journal.LoadFromFile(file);
            }
            else if (response == "4")
            {
                Console.Write("Enter the file name to save: ");
                string saveFile = Console.ReadLine();
                // Assuming Journal has a SaveToFile method
                journal.SaveToFile(saveFile);
            }

            Console.Write("What do you want to do?: ");
            response = Console.ReadLine();
        }

        Console.WriteLine("Exiting the journal program. Goodbye!");
    }
}