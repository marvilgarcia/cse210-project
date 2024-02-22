public class ChecklistGoal : Goal
{
    public int _amountComplete;
    public int _target;
    public int _bonus;

    public ChecklistGoal(string name, string description, string points, int target, int bonus) : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountComplete = 0; // Initialize amount complete to 0
    }

    public override void RecordEvent()
    {
        _amountComplete++;
        if (_amountComplete >= _target)
        {
            IsComplete(); // Call the MarkComplete method from the base class
            
        }
        
    }

    public override bool IsComplete()
    {
        return _amountComplete >= _target; 
    }

    public override string GetDetailString()
    {
        return $"Progress: {_amountComplete}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"Checklist Goal: {_shortName}, Description: {_description}, Points: {_points}, Progress: {_amountComplete}/{_target}";
    }
}
