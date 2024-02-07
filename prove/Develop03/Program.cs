using System;

public class Program
{
    public static void Main(string[] args)
    {
        ScriptureLibrary scriptureLibrary = new ScriptureLibrary();

        Scripture scripture = scriptureLibrary.GetRandomScripture();

        while (true)
        {
            Console.WriteLine(scripture.GetDisplayText());

            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("All words are hidden. Program ended.");
                break; // Exit the loop
            }

            Console.WriteLine("Press Enter to continue or type 'quit' to finish:");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break; 
            }

            int wordsToHide = new Random().Next(1, 4); // this code select a random number of words to hide
            scripture.HideRandomWords(wordsToHide);


            Console.Clear();
        }

        Console.WriteLine("Program ended.");
    }
}
