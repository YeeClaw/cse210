public class SimpleGoal : Goal
{
    public bool IsSatisfied { get; set; }

    public SimpleGoal(string shortName, string description, string points)
        : base(shortName, description, points)
    {
        IsSatisfied = false;
    }

    public SimpleGoal()
    {
        // Parameterless constructor is required for serialization ???
    }

    public override bool IsComplete()
    {
        return IsSatisfied;
    }
    
    public override void CompleteGoal()
    {
        IsSatisfied = true;
    }
}