using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Guessing Game!");
        Console.WriteLine("Your goal is to guess the magic number between 1 and 100.");

        Console.WriteLine("Would you like to play? (yes/no)");
        string play = Console.ReadLine();

        while (play == "yes")
        {
            int numGuesses = RunGuessGame();
            Console.WriteLine($"It took you {numGuesses} guesses to find the magic number.");

            Console.WriteLine("\nWould you like to play again? (yes/no)");
            play = Console.ReadLine();
        }

        Console.WriteLine("Thanks for playing!");
    }

    static int RunGuessGame()
    { 
        Random rnd = new();
        int magicNumber = rnd.Next(1, 101);
        // The `Next()` method takes advantage of a mechanic called method overloading. In this way, a method can
        // have multiple definitions, each with a different set of parameters.
        int guess;
        int attempts = 0;

        do
        {
            Console.WriteLine("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You got it!");
            }

            attempts++;
        } while (guess != magicNumber);

        return attempts;
    }
}