public class EternalGoal : Goal
{
    public int TimesCompleted { get; set; }
    
    public EternalGoal(string shortName, string description, string points)
        : base(shortName, description, points)
    {
        TimesCompleted = 0;
    }

    public EternalGoal()
    {
        // Parameterless constructor is required for serialization ???
    }
    
    public override bool IsComplete()
    {
        return false;
    }

    public override void CompleteGoal()
    {
        TimesCompleted++;
    }
}