public class Journal
{
    private int _choice;
    
    public string Owner { get; }
    private string PathFile { get; }
    private List<Entry> Entries { get; } = new();
    public int Choice
    {
        get => _choice;
        private set
        {
            if (value is < 1 or > 5)
                throw new ArgumentException("Invalid choice");
            _choice = value;
        }
    }
    
    public Journal(string owner, string pathFile)
    {
        Owner = owner;
        PathFile = pathFile;
    }

    public void DisplayMenu()
    {
        Console.WriteLine("Please select one of the following choices");
        Console.WriteLine("1. Write");
        Console.WriteLine("2. Display");
        Console.WriteLine("3. Load");
        Console.WriteLine("4. Save");
        Console.WriteLine("5. Quit");

        try
        {
            Choice = int.Parse(Console.ReadLine() ?? "0");
        } catch (Exception e)
        {
            // I've been looking for an awesome excuse to use recursion
            Console.WriteLine(e.Message);
            DisplayMenu();
        }
    }
    
    public void Write()
    {
        Entry entry = new();
        Entries.Add(entry);
    }
    
    public void Display()
    {
        foreach (var entry in Entries)
        {
            Console.WriteLine(entry.ToString());
        }
    }

    public void Load()
    {
        Console.WriteLine("WARNING: Loading will overwrite any unsaved changes.");
        Console.WriteLine("Would you like to:");
        Console.WriteLine($"1. Load from default path ({PathFile})");
        Console.WriteLine("2. Load from a different path");
        Console.WriteLine("3. Cancel");
        var response = int.Parse(Console.ReadLine() ?? "0");

        switch (response)
        {
            case 1:
                ReadFromFile(PathFile);
                break;
            case 2:
                Console.WriteLine("Please enter the path to read from");
                string path = Console.ReadLine();
                ReadFromFile(path);
                break;
            case 3:
                break;
            default:
                Console.WriteLine("Invalid choice");
                break;
        }
    }
    
    public void Save()
    {
        Console.WriteLine($"Would you like to:");
        Console.WriteLine($"1. Save to default path ({PathFile})");
        Console.WriteLine("2. Save to a different path");
        Console.WriteLine("3. Cancel");
        var response = int.Parse(Console.ReadLine() ?? "0");
        
        switch (response)
        {
            case 1:
                WriteToFile(PathFile);
                break;
            case 2:
                Console.WriteLine("Please enter the path to save the file");
                var path = Console.ReadLine();
                WriteToFile(path);
                break;
            case 3:
                break;
            default:
                Console.WriteLine("Invalid choice");
                break;
        }
    }

    private void WriteToFile(string path)
    {
        using StreamWriter outputFile = new(path);
        foreach (var entry in Entries)
        {
            outputFile.WriteLine(entry.ToFile());
        }
    }

    private void ReadFromFile(string path)
    {
        Entries.Clear();
        string[] lines = File.ReadAllLines(path);
        foreach (var line in lines)
        {
            string[] parts = line.Split('|');
            var entry = new Entry(parts[0], parts[1], parts[2]);
            
            Entries.Add(entry);
        }
    }
}