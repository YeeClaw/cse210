class Program
{
    static void Main(string[] args)
    {
        string input;
        Reference reference;
        Scripture myScripture;
        int wordsToHide;
        
        Console.WriteLine("Welcome to the Scripture Memory Game!\nWould you like to enter your own scripture? (y/n)");
        input = Console.ReadLine();

        if (input?.ToLower() == "y")
        {
            Console.Clear();

            string book;
            int chapter;
            int verse;
            int endVerse;
            
            Console.WriteLine("Enter the book:");
            book = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Enter the chapter:");
            chapter = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Console.Clear();
            Console.WriteLine("Enter the verse:");
            verse = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Console.Clear();
            Console.WriteLine("Enter the end verse (if not applicable, simply press enter):");
            if (!int.TryParse(Console.ReadLine(), out endVerse)) // This `out` parameter lets me assign a successful parse to a variable to endVerse
            {
                endVerse = 0;
            }
            Console.Clear();
            
            switch (endVerse)
            {
                case 0:
                    reference = new(book, chapter, verse);
                    break;
                default:
                    reference = new(book, chapter, verse, endVerse);
                    break;
            }
            
            Console.WriteLine("Enter the scripture text:");
            string scriptureText = Console.ReadLine();
            Console.Clear();
            
            Console.WriteLine("Enter the number of words to hide per round:");
            wordsToHide = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Console.Clear();
            
            myScripture = new(reference, scriptureText);
        }
        else
        {
            reference = new("Alma",41, 10);
            string scriptureText = "Do not suppose, because it has been spoken concerning restoration, that ye shall be restored from sin to happiness. Behold, I say unto you, wickedness never was happiness.";
            wordsToHide = 3;
            Console.Clear();
            
            myScripture = new(reference, scriptureText);
        }
        
        // It seems that in this class we make a lot of game loops. Maybe in the future I'll make a class for that in my free time.
        // It would also be smart to make this whole thing generic so that it can be used for any type of memory game.
        
        var lastCall = 0;
        
        do
        {
            if (myScripture.IsCompletelyHidden())
            {
                lastCall++;
            }
            
            Console.WriteLine(myScripture.GetDisplayText() + "\n");
            
            Console.WriteLine("Press enter to continue or type 'quit' to finish:");
            input = Console.ReadLine();
            
            myScripture.HideRandomWords(wordsToHide);
            Console.Clear();
        } while (input?.ToLower() != "quit" && lastCall < 1);
    }
}