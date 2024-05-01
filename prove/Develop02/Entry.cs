public class Entry
{
    private DateTime Date { get; }
    private string Content { get; }
    private string Prompt { get; }

    // Constructor for the case of creating a new entry
    public Entry()
    {
        Date = DateTime.Now;
        Prompt = GeneratePrompt();
        Console.WriteLine(Prompt);
        
        Content = Console.ReadLine();
    }
    
    // Constructor for the case of reading from a file
    public Entry(string date, string prompt, string content)
    {
        Date = DateTime.Parse(date);
        Prompt = prompt;
        Content = content;
    }

    // Utility methods
    private static string GeneratePrompt()
    {
        string fileName = "../../../prompts.txt";
        string[] prompts = File.ReadAllLines(fileName);
        
        Random rand = new();
        var index = rand.Next(prompts.Length);
        
        return prompts[index];
    }
    
    // Output methods
    public string ToFile()
    {
        return $"{Date}|{Prompt}|{Content}";
    }
    
    public override string ToString()
    {
        return $"{Date} - Prompt: {Prompt}\n{Content}\n";
    }
}