using Sandbox;

public class BreathingActivity : Activity
{
    public BreathingActivity(string name, string description) : base(name, description)
    {
        // Do we really even need this constructor?
    }

    public async Task Run()
    {
        while (Duration == 0){DisplayStartingMessage();} // Band-aid fix :(
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("NOTE: For the best experience, please make sure that your console window is maximized.");
        Console.ResetColor();
        Console.WriteLine("Get ready...");
        await ShowSpinner(5, 5);
        
        await StartSession();
        
        if (IsCursorOutOfBounds()) {Console.Clear();}
        await DisplayEndingMessage();
    }

    private async Task StartSession()
    {
        DateTime sessionEndTime = DateTime.Now.AddSeconds(Duration);
        
        string[] frames = File.ReadAllText("../../../frames.txt").Split("&");
        TextAnimation breathingIn = new(1, frames);
        TextAnimation breathingOut = new(1, frames);

        while (DateTime.Now < sessionEndTime)
        {
            if (IsCursorOutOfBounds()) {Console.Clear();}
            Console.WriteLine("\nBreathe in...");
            await breathingIn.Play();
            if (IsCursorOutOfBounds()) {Console.Clear();}
            Console.WriteLine("Now breathe out...");
            await breathingOut.ReversePlay();
        }
    }
    
}