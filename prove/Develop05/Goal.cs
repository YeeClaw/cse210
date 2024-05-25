using System.Runtime.CompilerServices;
using System.Xml.Serialization;

// These are class attributes. They are used to provide metadata about the class and in this case allow
// the XmlSerializer to know that it should also serialize the derived classes of Goal.
[XmlInclude(typeof(SimpleGoal))]
[XmlInclude(typeof(ChecklistGoal))]
[XmlInclude(typeof(EternalGoal))]
public abstract class Goal
{
    public string ShortName { get; set; }
    public string Description { get; set; }
    public string Points { get; set; }
    
    public Goal(string shortName, string description, string points)
    {
        ShortName = shortName;
        Description = description;
        Points = points;
    }

    public Goal()
    {
        // Parameterless constructor is required for serialization ???
    }

    public abstract void CompleteGoal();
    public abstract bool IsComplete();

    protected string GetCheck()  // Protected is like private, but also accessible to derived classes
    {
        if (IsComplete())
        {
            return "[X]";
        }
        else
        {
            return "[ ]";
        }
    }

    public virtual string GetDetailsString()
    {
        return $"{GetCheck()} {ShortName} - {Description} ({Points})";
    }
}