public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, string points) : base(name, description, points)
    {
    }

    public override bool IsComplete()
    {
        return false; // Eternal goals are never complete
    }

    public override void RecordEvent()
    {
    }

    public override string GetStringRepresentation()
    {
        return $"Eternal Goal: {_shortName}, Description: {_description}, Points: {_points}";
    }
}