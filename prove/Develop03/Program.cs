using System;

public class Program
{
    public static void Main(string[] args)
    {
        // Instantiate a ScriptureLibrary object to hold the library of scriptures
        ScriptureLibrary scriptureLibrary = new ScriptureLibrary();

        // Get a random scripture from the library
        Scripture scripture = scriptureLibrary.GetRandomScripture();

        // Loop until all words in the scripture are hidden, the user quits, or all words are revealed
        while (true)
        {
            // Display the complete scripture text initially
            Console.WriteLine($"Complete Scripture ({scripture.Reference}):");
            Console.WriteLine(scripture.GetDisplayText());

            // Check if all words in the scripture are hidden
            if (scripture.IsCompletelyHidden())
            {
                // Display a message indicating that all words are hidden
                Console.WriteLine("All words are hidden. Program ended.");
                break; // Exit the loop
            }

            // Prompt the user to press enter to hide more words or quit
            Console.WriteLine("Press Enter to continue or type 'quit' to finish:");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break; // Exit the loop and end the program
            }

            // Hide a random number of words
            int wordsToHide = new Random().Next(1, 4); // Adjust the range according to your preference
            scripture.HideRandomWords(wordsToHide);


            // Clear the console screen
            Console.Clear();
        }

        // Display a message indicating that the program has ended
        Console.WriteLine("Program ended.");
    }
}
