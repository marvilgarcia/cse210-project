using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                // Write each entry to a new line in the file
                outputFile.WriteLine($"{entry._date}-{entry._promptText}-{entry._entryText}");
            }
        }
    }

    public void LoadFromFile(string file)
    {
        string[] lines = File.ReadAllLines(file);

        foreach (string line in lines)
        {
            string[] parts = line.Split("-");

            if (parts.Length >= 3)
            {
                string date = parts[0].Trim();
                string prompt = parts[1].Trim();
                string entryText = parts[2].Trim();

                // Create an Entry object and add it to the list
                Entry loadedEntry = new Entry
                {
                    _date = date,
                    _promptText = prompt,
                    _entryText = entryText
                };
                _entries.Add(loadedEntry);
            }
            else
            {
                Console.WriteLine($"Invalid line format: {line}");
            }
        }
    }
}

