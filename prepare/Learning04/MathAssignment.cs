public class MathAssignment : Assignment
{
    public string TextBookSection { get; set; }
    public string ProblemSet { get; set; }
    
    public MathAssignment(string studentName, string topic, string textBookSection, string problem) : base(studentName, topic)
    // This constructor feels really long. I wonder if I can break the base into a parameterless constructor to make things more readable.
    {
        TextBookSection = textBookSection;
        ProblemSet = problem;
    }

    public string GetHomeworkList()
    {
        var homeworkList = $"Section {TextBookSection} Problems {ProblemSet}"; // Var is cool because it makes things more readable.
        return homeworkList;
    }
}