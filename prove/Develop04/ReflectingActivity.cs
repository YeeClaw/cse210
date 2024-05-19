public class ReflectingActivity : Activity
{
    public string[] Prompts { get; set; }
    public string[] Questions { get; set; }
    
    private Random _randGen = new();
    private List<int> _chosenQuestions;
    private int _secondsPerQuestion;
    
    public ReflectingActivity(string name, string description) : base(name, description)
    {
        Prompts = File.ReadAllText("../../../prompts.txt").Replace("\n", "").Replace("\r", "").Split("&");
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
        DisplayStartingMessage();

        await StartSession();
        
        await DisplayEndingMessage();
    }

    public async Task StartSession()
    {
        Console.Clear();
        Console.WriteLine("Get ready...");
        await ShowSpinner(5, 5);
        
        await DisplayPrompt();
        await DisplayQuestions();
    }

    public string GetRandomPrompt()
    {
        return Prompts[_randGen.Next(Prompts.Length)];
    }
    
    public void PopulateRandomQuestions()
    {
        _chosenQuestions.Clear();
        if (Duration <= Questions.Length * _secondsPerQuestion)
        {
            for (var i = 0; i < (Duration / _secondsPerQuestion); i++)
            {
                int index = _randGen.Next(Questions.Length);
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
                int index = _randGen.Next(Questions.Length);
                if (_chosenQuestions.Contains(index))
                {
                    i--;
                    continue;
                }
                _chosenQuestions.Add(index);
            }
        }
    }
    
    public async Task DisplayPrompt()
    {
        Console.WriteLine("\nConsider the following prompt:");
        Console.WriteLine($"--- {GetRandomPrompt()} ---");

        Console.WriteLine("\nWhen you have something in mind, press enter to continue");
        Console.ReadLine();
        
        Console.WriteLine("\nNow ponder on each of the following questions as they related to this experience");
        Console.Write("You may begin in: ");
        await ShowCountDown();
        Console.Clear();
    }

    public async Task DisplayQuestions()
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