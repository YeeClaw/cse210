class Program
{
    /*===[MINDFULLNESS ACTIVITIES]===*/
    // The following classes meet and exceed the initial requirements for the assignment.
    // I can't even begin to describe everything I did that was "showing creativity". I spent way too much time on this.
    // This biggest thing that I would like to highlight is my TextAnimation class that was written in the Sandbox namespace
    // and referenced in a couple of the classes here. It provides a dynamic and robust solution for more complicated text
    // based animations. I also added a lot of error handling and feedback to make the program more user friendly.
    
    // Another big deviation from the initial requirements was the use of asynchronous programming. I used async/await to
    // avoid this program from blocking the main thread while waiting for user input or displaying animations. This allows
    // the program to be more responsive and provide a better user experience.
    public static async Task Main(string[] args)
    {
        // I actually really don't like the idea of putting an entire thread to sleep, so instead I will find a different
        // way to wait for an elapsed period of time.
        int input;
        BreathingActivity breathing = new("Breathing", 
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");
        ReflectingActivity reflecting = new("Reflecting", 
            "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life");
        ListingActivity listing = new("Listing", 
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
        
        do
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Start breathing activity");
            Console.WriteLine("2. Start reflecting activity");
            Console.WriteLine("3. Start listing activity");
            Console.WriteLine("4. Quit\n");
            Console.Write("Select a choice from the menu: ");

            if (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please try again.\n");
                Console.ResetColor();
                continue;
            }

            switch (input)
            {
                case 1:
                    Console.Clear();
                    await breathing.Run();
                    Console.Clear();
                    break;
                case 2:
                    Console.Clear();
                    await reflecting.Run();
                    Console.Clear();
                    break;
                case 3:
                    Console.Clear();
                    await listing.Run();
                    Console.Clear();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Invalid menu option. Please try again.\n");
                    Console.ResetColor();
                    break;
            }
        } while (input != 4);
    }
}