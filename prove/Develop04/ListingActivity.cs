public class ListingActivity : Activity
{
    public int Count { get; set; }
    
    public ListingActivity(string name, string description) : base(name, description)
    {
        
    }

    public async Task Run()
    {
        Count = 0;
        while (Duration == 0){DisplayStartingMessage();} // Band-aid fix :(

        await StartSession();
        
        if (IsCursorOutOfBounds()) {Console.Clear();}
        Console.WriteLine($"You listed {Count} items!");
        await DisplayEndingMessage();
    }
    
    private async Task StartSession()
    {
        Console.Clear();
        Console.WriteLine("Get ready...");
        await ShowSpinner(5, 5);
        
        await DisplayPrompt();
        GetListFromUser();
    }
    
    private async Task DisplayPrompt()
    {
        Console.WriteLine("\nList as many responses you can to the following prompt:");
        Console.WriteLine($"--- {GetRandomPrompt("../../../listprompts.txt")} ---");
        Console.Write("You may begin in: ");
        await ShowCountDown();
    }

    private List<string> GetListFromUser()
    {
        var endTime = DateTime.Now.AddSeconds(Duration);
        var list = new List<string>();
        Console.WriteLine();
        while (DateTime.Now <= endTime)
        {
            Console.Write("> ");
            list.Add(Console.ReadLine());
            Count++;
        }
        
        return list;
    }
}