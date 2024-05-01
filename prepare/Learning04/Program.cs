class Program
{
    static void Main(string[] args)
    {
        Reference verse = new("Alma",41, 10);

        string scriptureText = "Do not suppose, because it has been spoken concerning restoration, that ye shall be restored from sin to happiness. Behold, I say unto you, wickedness never was happiness.";
        Scripture myScripture = new(verse, scriptureText);

        
        myScripture.Display();
    }
}