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
        try
        {
            using (StreamWriter outputFile = new StreamWriter(file))
            {
                // Write header row
                outputFile.WriteLine("Date,Prompt,Entry");
                

                foreach (Entry entry in _entries)
                {
                   
                    // Format entry as CSV and write to file
                    outputFile.WriteLine($"\"{entry._date}\",\"{entry._promptText}\",\"{entry._entryText}\"");
                }
            }

            Console.WriteLine("Save successful.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving to file: {ex.Message}");
        }
    }
    public void LoadFromFile(string file)
    {
        try
        {
            // Clear existing entries before loading new ones
            _entries.Clear();

            string[] lines = File.ReadAllLines(file);

            // Skip header row if present
            int startIndex = lines[0].StartsWith("Date,Prompt,Entry") ? 1 : 0;

            for (int i = startIndex; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] parts = line.Split(',');

                if (parts.Length == 3)
                {
                    // Extract fields and create Entry object
                    string date = parts[0].Trim('"');
                    string prompt = parts[1].Trim('"');
                    string entryText = parts[2].Trim('"');

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
                    Console.WriteLine($"Invalid line format in CSV: {line}");
                }
            }

            Console.WriteLine("Load successful.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading from file: {ex.Message}");
        }
    }


}