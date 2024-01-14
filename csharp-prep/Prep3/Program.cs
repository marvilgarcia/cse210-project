using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is the magic number? ");
        string magicNumber = Console.ReadLine();
        int x = int.Parse(magicNumber);

        while (true)
        {
            Console.Write("What is your guess? ");
            int userGuess = int.Parse(Console.ReadLine());

            if (userGuess < x)
            {
                Console.WriteLine("Higher");
            }
            else if (userGuess > x)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
                break; // Exit the loop when the guess is correct
            }
        }

        
    }
}