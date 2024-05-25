public class ChecklistGoal : Goal
{
    public int AmountCompleted { get; set; }
    public int Target { get; set; }
    public int Bonus { get; set; }
    
    public ChecklistGoal(string shortName, string description, string points, int target, int bonus)
        : base(shortName, description, points)
    {
        AmountCompleted = 0;
        Target = target;
        Bonus = bonus;
    }
    
    public ChecklistGoal()
    {
        // Parameterless constructor is required for serialization ???
    }
    
    public override bool IsComplete()
    {
        return AmountCompleted >= Target;
    }
    
    public override void CompleteGoal()
    {
        if (IsComplete())
        {
            throw new InvalidOperationException("Goal is already complete.");
        }
        
        AmountCompleted++;
    }
    
    public override string GetDetailsString()
    {
        return $"{GetCheck()} {ShortName} - {Description} ({Points}) ({AmountCompleted}/{Target})";
    }
}