using System.Xml.Serialization;

public class GoalManager
{
    public List<Goal> Goals { get; set; }
    public int Score { get; set; }
    public XmlSerializer Serializer { get; } = new(typeof(GoalManager));
    
    public GoalManager()
    {
        Goals = new List<Goal>();
        Score = 0;
    }

    public void Start()
    {
        var input = "";
        do
        {
            DisplayPlayerInfo();
        
            Console.WriteLine("Menu options:");
            Console.WriteLine("1. Create new goal");
            Console.WriteLine("2. List goals");
            Console.WriteLine("3. Save profile");
            Console.WriteLine("4. Load profile");
            Console.WriteLine("5. Record event");
            Console.WriteLine("6. Exit");
            Console.Write("\nSelect a choice from the menu: ");
            input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.Clear();
                    CreateGoal();
                    Console.Clear();
                    break;
                case "2":
                    Console.Clear();
                    ListGoalDetails();
                    Console.Clear();
                    break;
                case "3":
                    Console.Clear();
                    SaveProfile();
                    break;
                case "4":
                    Console.Clear();
                    LoadProfile();
                    break;
                case "5":
                    Console.Clear();
                    RecordEvent();
                    Console.Clear();
                    break;
                case "6":
                    Console.Clear();
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please try again.");
                    Console.ResetColor();
                    break;
            }
        }
        while (input != "6");
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {Score} points.\n");
    }

    public void ListGoalNames()
    {
        foreach (var goal in Goals)
        {
            Console.WriteLine(goal.ShortName);
        }
    }
    
    public void ListGoalDetails()
    {
        foreach (var goal in Goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
        Console.Write("\nPress any key to continue...");
        Console.ReadKey(); // Works like ReadLine but only grabs the key pressed
    }
    
    public void CreateGoal()
    {
        Console.WriteLine("The types of goals are:\n");
        Console.WriteLine("1. Simple goal");
        Console.WriteLine("2. Eternal goal");
        Console.WriteLine("3. Checklist goal");
        Console.WriteLine("4. Back to menu");
        
        Console.Write("\nWhich type of goal would you like to create? ");
        var input = Console.ReadLine();
        
        Dictionary<string, string> basicInfo;
        Goal goal;

        switch (input)
        {
            case "1":
                basicInfo = GetBasicGoalInfo();
                goal = new SimpleGoal
                    (
                        basicInfo["shortName"],
                        basicInfo["description"],
                        basicInfo["points"]
                    );
                Goals.Add(goal);
                break;
            case "2":
                basicInfo = GetBasicGoalInfo();
                goal = new EternalGoal
                    (
                        basicInfo["shortName"],
                        basicInfo["description"],
                        basicInfo["points"]
                    );
                Goals.Add(goal);
                break;
            case "3":
                basicInfo = GetBasicGoalInfo();
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                var target = int.Parse(Console.ReadLine() ?? "3"); // If null, default to 3
                Console.Write($"What is the bonus for accomplishing this goal {target} times? ");
                var bonus = int.Parse(Console.ReadLine() ?? "500"); // If null, default to 500
                goal = new ChecklistGoal
                    (
                        basicInfo["shortName"],
                        basicInfo["description"],
                        basicInfo["points"],
                        target,
                        bonus
                    );
                Goals.Add(goal);
                break;
            case "4":
                break;
            default:
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Input");
                Console.ResetColor();
                break;
        }
    }
    
    public void RecordEvent()
    {
        // This method could probably be abstracted further.
        Console.WriteLine("The goals are:\n");
        for (var i = 0; i < Goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Goals[i].ShortName}");
        }
        Console.Write("\nWhich goal would you like to accomplish today? ");
        int desiredGoalIndex;

        try
        {
            if (int.TryParse(Console.ReadLine(), out desiredGoalIndex))
            {
                Goals[desiredGoalIndex - 1].CompleteGoal();
                int totalPoints;

                // This is a messy way to handle the bonus points for a checklist goal
                if (Goals[desiredGoalIndex - 1].IsComplete() && Goals[desiredGoalIndex - 1] is ChecklistGoal)
                {
                    totalPoints = int.Parse(Goals[desiredGoalIndex - 1].Points) + ((ChecklistGoal) Goals[desiredGoalIndex - 1]).Bonus;
                }
                else
                {
                    totalPoints = int.Parse(Goals[desiredGoalIndex - 1].Points);
                }
                
                Score += totalPoints;
                
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Congratulations! You've earned {totalPoints} points!");
                
                Console.WriteLine($"\nYou now have {Score} points.");
                Console.ResetColor();
                
                Console.Write("\nPress any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please try again.");
                Console.ResetColor();
                RecordEvent();
            }
        } catch (ArgumentOutOfRangeException)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Goal is not listed. Please try again.");
            Console.ResetColor();
            RecordEvent();
        }
        
    }

    public void SaveProfile()
    {
        var filename = CollectFilename();
        
        if (!Directory.Exists("../../savedgoals"))
        {
            Directory.CreateDirectory("../../savedgoals");
        }
        
        using (StreamWriter writer = new($"../../savedgoals/{filename}.xml"))
        {
            Serializer.Serialize(writer, this);
        }

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Profile saved successfully.");
        Console.ResetColor();
    }
    
    public void LoadProfile()
    {
        var filename = CollectFilename();

        if (File.Exists($"../../savedgoals/{filename}.xml"))
        {
            using (StreamReader reader = new($"../../savedgoals/{filename}.xml"))
            {
                var loadedManager = (GoalManager) Serializer.Deserialize(reader);
                
                if (loadedManager == null)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Error loading goals: file is empty.");
                    Console.ResetColor();
                    return;
                }
                
                Goals = loadedManager.Goals;
                Score = loadedManager.Score;
            }
            
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Profile loaded successfully.");
            Console.ResetColor();
        }
        else
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Error loading goals: file not found.");
            Console.ResetColor();
        }
    }

    private string CollectFilename()
    {
        Console.Write("What is the filename for the profile you'd like? (without extension)? ");
        var filename = Console.ReadLine();
        
        return filename;
    }
    
    private Dictionary<string, string> GetBasicGoalInfo()
    {
        Console.Clear();
        var output = new Dictionary<string, string>();
        
        Console.Write("What is the name of your goal? ");
        output["shortName"] = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        output["description"] = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        output["points"] = Console.ReadLine();
        
        return output;
    }
}