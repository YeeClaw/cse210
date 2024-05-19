public class ReflectingActivity : Activity
{
    public string[] Questions { get; set; }
    
    private List<int> _chosenQuestions;
    private int _secondsPerQuestion;
    
    public ReflectingActivity(string name, string description) : base(name, description)
    {
        Questions = File.ReadAllText("../../../questions.txt").Replace("\n", "").Replace("\r", "").Split("&");

        _secondsPerQuestion = 10;
        if (Duration <= Questions.Length * _secondsPerQuestion)
        {
            _chosenQuestions = new List<int>(Duration / _secondsPerQuestion);
        }
        else
        {
            _chosenQuestions = new List<int>(Questions.Length);
        }
       
    }

    public async Task Run()
    {
        while (Duration == 0){DisplayStartingMessage();} // Band-aid fix :(

        await StartSession();
        
        if (IsCursorOutOfBounds()) {Console.Clear();}
        await DisplayEndingMessage();
    }

    private async Task StartSession()
    {
        Console.Clear();
        Console.WriteLine("Get ready...");
        await ShowSpinner(5, 5);
        
        await DisplayPrompt();
        await DisplayQuestions();
    }
    
    private void PopulateRandomQuestions()
    {
        _chosenQuestions.Clear();
        if (Duration <= Questions.Length * _secondsPerQuestion)
        {
            for (var i = 0; i < (Duration / _secondsPerQuestion); i++)
            {
                int index = RandGen.Next(Questions.Length);
                if (_chosenQuestions.Contains(index))
                {
                    i--;
                    continue;
                }
                _chosenQuestions.Add(index);
            }
        }
        else
        {
            for (var i = 0; i < (Questions.Length); i++)
            {
                int index = RandGen.Next(Questions.Length);
                if (_chosenQuestions.Contains(index))
                {
                    i--;
                    continue;
                }
                _chosenQuestions.Add(index);
            }
        }
    }
    
    private async Task DisplayPrompt()
    {
        Console.WriteLine("\nConsider the following prompt:");
        Console.WriteLine($"--- {GetRandomPrompt("../../../prompts.txt")} ---");

        Console.WriteLine("\nWhen you have something in mind, press enter to continue");
        Console.ReadLine();
        
        Console.WriteLine("\nNow ponder on each of the following questions as they related to this experience");
        Console.Write("You may begin in: ");
        await ShowCountDown();
        Console.Clear();
    }

    private async Task DisplayQuestions()
    {
        PopulateRandomQuestions();
        
        foreach (var question in _chosenQuestions)
        {
            Console.Write("\n> " + Questions[question] + " ");
            await ShowSpinner(5, _secondsPerQuestion);
            Console.WriteLine();
            if (IsCursorOutOfBounds())
            {
                Console.Clear();
            }
        }
    }
}