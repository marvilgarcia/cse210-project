using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        while (true)
        {
            Console.Write("Enter number: ");
            int input = int.Parse(Console.ReadLine());

            if (input == 0)
            {
                break; 
            }

            numbers.Add(input);
        }

        if (numbers.Count > 0)
        {
            // Compute the sum
            int sum = 0;
            foreach (int number in numbers)
            {
                sum += number;
            }

            // Compute the average
            double average = (double)sum / numbers.Count;

            // Find the maximum number
            int max = numbers[0];
            foreach (int number in numbers)
            {
                if (number > max)
                {
                    max = number;
                }
            }

            Console.WriteLine($"The sum is: {sum}");
            Console.WriteLine($"The average is: {average}");
            Console.WriteLine($"The largest number is: {max}");
        }
        else
        {
            Console.WriteLine("No numbers entered.");
        }
    }
}