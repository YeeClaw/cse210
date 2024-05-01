using System;
// My program shows creativity in the way it handles file I/O. Instead of prompting the user for a path to read from or write to, I have the program automatically
// read and write to a file named "journal.txt" in the same directory as the program.

// This makes the program easier to use and understand, as the user doesn't have to worry about file paths. The program also catches exceptions when loading a file,
// which is a good practice to ensure the program doesn't crash if the file is missing or corrupted.

// Additionally, the program has been maximized for reusability. Everything is encapsulated to the best of my ability, and the program is designed with principals
// of abstraction in mind. Everything is broken down into classes and methods that are easy to understand and modify.
class Program
{
    static void Main(string[] args)
    {
        Journal myJournal = new("Austin", "journal.txt");

        Console.WriteLine($"Welcome, {myJournal.Owner}!");
        do
        {
            myJournal.DisplayMenu();
            switch (myJournal.Choice)
            {
                case 1:
                    myJournal.Write();
                    break;
                case 2:
                    myJournal.Display();
                    break;
                case 3:
                    try
                    {
                        myJournal.Load();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;
                case 4:
                    myJournal.Save();
                    break;
            }
        } while (myJournal.Choice != 5);
        
        Console.WriteLine("Thank you for writing today. Goodbye!");
    }
}