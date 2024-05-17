public class Program
{
    public static void Main(string[] args)
    {
        MathAssignment mathHomework = new("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        WritingAssignment writingAssignment = 
            new("Mary Walters", "European History", "The Causes of World War II by Mary Waters");

        Console.WriteLine(mathHomework.GetSummary());
        Console.WriteLine($"{mathHomework.GetHomeworkList()}\n");
        
        Console.WriteLine(writingAssignment.GetSummary());
        Console.WriteLine($"{writingAssignment.GetWritingInformation()}\n");
    }
}