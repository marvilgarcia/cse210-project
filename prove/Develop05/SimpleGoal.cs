public class SimpleGoal : Goal
{
    private bool _isCompleted;

    public SimpleGoal(string name, string description, string points) : base(name, description, points)
    {
        _isCompleted = false; // Initialize _isCompleted to false
    }

    public override void RecordEvent()
    {
        _isCompleted = true; // Mark the goal as complete when an event is recorded
    }

    public override bool IsComplete()
    {
        return _isCompleted; // Return the value of _isCompleted
    }

    public override string GetStringRepresentation()
    {
        return $"Simple Goal: {_shortName}, Description: {_description}, Points: {_points}, IsCompleted: {_isCompleted}";
    }

}