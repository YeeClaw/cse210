using Sandbox;

public class Activity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Duration
    {
        get => _duration;
        set
        {
            if (value < 10)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Duration must be at least 10 seconds. Please try again.\n");
                Console.ResetColor();
                Console.ReadLine();
                DisplayStartingMessage();
            }

            _duration = value;
        }
    }
    
    private int _duration;

    public Activity(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {Name} Activity!\n");
        Console.WriteLine(Description + "\n");

        Console.Write("How long, in seconds, would you like for your session? ");
        int duration;
        if (!int.TryParse(Console.ReadLine(), out duration))
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid input. Please try again.\n");
            Console.ResetColor();
            DisplayStartingMessage();
        }
        
        Duration = duration;
    }
    
    public async Task DisplayEndingMessage()
    {
        Console.ForegroundColor = ConsoleColor.Green;
            
        Console.WriteLine("\nWell done!");
        await ShowSpinner(5, 3);
        Console.WriteLine($"\nYou have completed another {Duration} seconds of the {Name} activity.");
        Console.ResetColor();
        await ShowSpinner(10, 7);
    }

    public async Task ShowSpinner(int fps, double duration)
    {
        TextAnimation spinner = new(fps, new []{ "|", "/", "-", "\\" });
        // TextAnimation spinner = new(fps, new []{ ">--", "->-", "-->", "--<", "-<-", "<--" });
        await spinner.Play(duration);
    }
    
    public async Task ShowCountDown()
    {
        TextAnimation countDown = new(1, new []{ "3", "2", "1" });
        await countDown.Play();
    }
    
    public bool IsCursorOutOfBounds()
    {
        if (Console.CursorTop >= Console.WindowHeight - 10)
        {
            return true;
        }
        return false;
    }
}