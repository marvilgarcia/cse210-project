using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
    
        List<Event> events = new List<Event>();

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("What type of event do you want to organize");
            Console.WriteLine("1. Lecture");
            Console.WriteLine("2. Reception");
            Console.WriteLine("3. Outdoor Gathering");
            Console.WriteLine("4. Exit");
            Console.Write("Choose the type of event: ");


            if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > 4)
            {
                Console.WriteLine("Invalid choice. Please try again.");
                continue;
            }

            if (choice == 4)
            {
                break;
            }

            Console.WriteLine();
            Console.Write("Enter the event title: ");
            string title = Console.ReadLine();

            Console.Write("Enter the event description: ");
            string description = Console.ReadLine();

            Console.Write("Enter the event date: ");
            string date = Console.ReadLine();

            Console.Write("Enter the event time: ");
            string time = Console.ReadLine();

            Console.Write("Enter the event address - street address: ");
            string streetAddress = Console.ReadLine();

            Console.Write("Enter the event address - city: ");
            string city = Console.ReadLine();

            Console.Write("Enter the event address - state/province: ");
            string stateProvince = Console.ReadLine();

            Console.Write("Enter the event address - country: ");
            string country = Console.ReadLine();

            Address address = new Address(streetAddress, city, stateProvince, country);

            Event newEvent;

            switch (choice)
            {
                case 1:
                    Console.Write("Enter the speaker's name: ");
                    string speakerName = Console.ReadLine();

                    Console.Write("Enter the capacity: ");
                    int capacity = int.Parse(Console.ReadLine());

                    newEvent = new Lecture(title, description, date, time, address, speakerName, capacity);
                    break;
                case 2:
                    Console.Write("Enter the RSVP email: "); 
                    string rsvpEmail = Console.ReadLine();

                    newEvent = new Reception(title, description, date, time, address, rsvpEmail);
                    break;
                case 3:
                    Console.Write("Enter the weather forecast: ");
                    string weatherForecast = Console.ReadLine();

                    newEvent = new OutdoorGathering(title, description, date, time, address, weatherForecast);
                    break;
                default:
                    continue;
            }

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("How do you want to show the detail?:");
                Console.WriteLine("1. Standard details");
                Console.WriteLine("2. Full details");
                Console.WriteLine("3. Short description");
                Console.WriteLine("4. Finish");
                Console.Write("Choose the details type: ");



                if (!int.TryParse(Console.ReadLine(), out int detailsChoice) || detailsChoice < 1 || detailsChoice > 4)
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                    continue;
                }

                if (detailsChoice == 4)
                {
                    events.Add(newEvent);
                    break;
                }

                string details;
                switch (detailsChoice)
                {
                    case 1:
                        details = newEvent.GetStandardDetails();
                        break;
                    case 2:
                        details = newEvent.GetFullDetails();
                        break;
                    case 3:
                        details = newEvent.GetShortDescription();
                        break;
                    default:
                        details = "Invalid choice";
                        break;
                }

                Console.WriteLine(details);
            }
        }

        foreach (var e in events)
        {
            Console.WriteLine(e.GetFullDetails());
            Console.WriteLine();
        }
    }
}
