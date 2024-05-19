using Sandbox;

public class BreathingActivity : Activity
{
    public BreathingActivity(string name, string description) : base(name, description)
    {
        // Do we really even need this constructor?
    }

    public async Task Run()
    {
        DisplayStartingMessage();
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("NOTE: For the best experience, please make sure that your console window is maximized.");
        Console.ResetColor();
        Console.WriteLine("Get ready...");
        await ShowSpinner(5, 5);
        
        await StartSession();
        
        await DisplayEndingMessage();
    }

    private async Task StartSession()
    {
        DateTime sessionEndTime = DateTime.Now.AddSeconds(Duration);
        
        string[] frames = File.ReadAllText("../../../frames.txt").Split("&");
        TextAnimation breathingIn = new(1, frames);
        TextAnimation breathingOut = new(2, frames);

        while (DateTime.Now < sessionEndTime)
        {
            if (IsCursorOutOfBounds())
            {
                Console.Clear();
            }
            Console.WriteLine("\nBreathe in...");
            await breathingIn.Play();
            Console.WriteLine("Now breathing out...");
            await breathingOut.ReversePlay();
        }
    }
    
}