using System;

class Program
{
    static void Main(string[] args)
    {
        Logger logger = new Logger("log.txt");
        logger.LoadLog();

        while (true)
        {
            Console.WriteLine("Menu options:");
            Console.WriteLine("1. Start breathing Activity");
            Console.WriteLine("2. Start reflection Activity");
            Console.WriteLine("3. Start listing Activity");
            Console.WriteLine("4. Display activity counts");
            Console.WriteLine("5. Quit");

            Console.Write("Select a choice from the menu: ");
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid choice. Please try again.");
                continue;
            }

            if (choice == 1)
            {
                Console.Clear();
                logger.Log("Starting Breathing Activity.");
                logger.IncrementActivityCount("Breathing Activity");
                new BreathingActivity().Run();
            }
            else if (choice == 2)
            {
                Console.Clear();
                logger.Log("Starting Reflecting Activity.");
                logger.IncrementActivityCount("Reflecting Activity");
                new ReflectingActivity().Run();
            }
            else if (choice == 3)
            {
                Console.Clear();
                logger.Log("Starting Listing Activity.");
                logger.IncrementActivityCount("Listing Activity");
                new ListingActivity().Run();
            }
            else if (choice == 4)
            {
                Console.Clear();
                logger.DisplayActivityCounts();
            }
            else if (choice == 5)
            {
                logger.Log("Exiting program.");
                Console.WriteLine("Exiting program...");
                return;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }
}