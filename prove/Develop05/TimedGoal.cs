using System.Diagnostics;

public class TimedGoal : Goal
{
    public TimeSpan _expectedTime;
    public TimeSpan _remainingTime;

    public DateTime _createdAt;
    private bool _isCompleted;

    public TimedGoal(string name, string description, string points, TimeSpan expectedTime, TimeSpan remainingTime) : base(name, description, points)
    {
    _shortName = name;
    _description = description;
    _points = points;
    _expectedTime = expectedTime;
    _remainingTime = remainingTime;
    _createdAt = DateTime.Now;
    _isCompleted = false;
    }

    public override void RecordEvent()
    {
        // Update remaining time
        if (_remainingTime >= TimeSpan.Zero)
        {
            _isCompleted = true;
        }

        // Mark as complete if time is up
        if (_remainingTime < TimeSpan.Zero)
        {
            IsComplete();
        }
    }

    public override bool IsComplete()
    {
        return _isCompleted;
    }

    public override string GetStringRepresentation()
    {
        return $"Timed Goal: {_shortName}, Description: {_description}, Points: {_points}, Expected Time: {_expectedTime} hours, Remaining Time: {_remainingTime} hours";
    }

    public static bool ParseExpectedTime(string input, out TimeSpan expectedTime)
    {
        // Split the input into number and unit
        string[] parts = input.Split(' ');
        if (parts.Length != 2)
        {
            throw new ArgumentException("Invalid expected time format. Expected format: <number> <unit> (e.g., '5 hours')");
        }

        int amount = int.Parse(parts[0]);
        string unit = parts[1].ToLower();

        // Check if the unit is singular and convert it to plural if necessary
        if (amount == 1 && unit.EndsWith("s"))
        {
            unit = unit.Substring(0, unit.Length - 1); // Remove the 's' at the end
        }

        // Convert the unit to a TimeSpan
        switch (unit)
        {
            case "hour":
            case "hours":
                expectedTime = TimeSpan.FromHours(amount);
                return true;
            case "day":
            case "days":
                expectedTime = TimeSpan.FromDays(amount);
                return true;
            case "week":
            case "weeks":
                expectedTime = TimeSpan.FromDays(amount * 7);
                return true;
            case "month":
            case "months":
                expectedTime = TimeSpan.FromDays(amount * 30); 
                return true;
            default:
                throw new ArgumentException("Invalid unit. Expected units: hour(s), day(s), week(s), month(s)");
        }
    }   

    public string GetFormattedRemainingTime()
    {
        TimeSpan remaining = _expectedTime - (DateTime.Now - _createdAt);
        if (remaining.TotalMilliseconds <= 0)
        {
            return "Time's up!";
        }
        return remaining.ToString(@"hh\:mm\:ss");
    }

}