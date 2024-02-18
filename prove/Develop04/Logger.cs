using System;
using System.IO;
using System.Collections.Generic;

public class Logger
{
    private string logFileName;
    private Dictionary<string, int> activityCount;

    public Logger(string fileName)
    {
        logFileName = fileName;
        activityCount = new Dictionary<string, int>();
    }

    public void Log(string message)
    {
        using (StreamWriter sw = File.AppendText(logFileName))
        {
            sw.WriteLine($"{DateTime.Now} - {message}");
        }
    }

    public void LoadLog()
    {
        if (File.Exists(logFileName))
        {
            using (StreamReader sr = File.OpenText(logFileName))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
        else
        {
            Console.WriteLine("Log file not found.");
        }
    }

    public void IncrementActivityCount(string activityName)
    {
        if (activityCount.ContainsKey(activityName))
        {
            activityCount[activityName]++;
        }
        else
        {
            activityCount[activityName] = 1;
        }
    }

    public void DisplayActivityCounts()
    {
        Console.WriteLine("Activity Counts:");
        foreach (var kvp in activityCount)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }
    }
}
