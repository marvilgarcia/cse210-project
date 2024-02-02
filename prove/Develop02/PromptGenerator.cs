using System;
using System.Collections.Generic;

public class PromptGenerator
{
    public List<string> _prompts;

    // Constructor to initialize the _prompts list
    public PromptGenerator()
    {
        _prompts = new List<string>();
    }

    public string GetRandomPrompt()
    {
        // Ensure that _prompts is not null before accessing Count
        if (_prompts == null || _prompts.Count == 0)
        {
            // Handle the case where _prompts is not initialized or is empty
            return "No prompts available.";
        }

        Random random = new Random();
        int randomIndex = random.Next(_prompts.Count);
        string randomPrompt = _prompts[randomIndex];

        return randomPrompt;
    }
}
