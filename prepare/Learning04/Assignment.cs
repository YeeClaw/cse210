public class Assignment
{
    public string StudentName { get; set; }
    public string Topic { get; set; }
    
    public Assignment(string studentName, string topic)
    {
        StudentName = studentName;
        Topic = topic;
    }

    public string GetSummary()
    {
        var summary = $"{StudentName} - {Topic}";
        return summary;
    }
}