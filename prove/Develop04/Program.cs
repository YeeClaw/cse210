using System;
using System.Net;

class Program
{
    public static async Task Main(string[] args)
    {
        // I actually really don't like the idea of putting an entire thread to sleep, so instead I will find a different
        // way to wait for an elapsed period of time.
        int input;
        BreathingActivity breathing = new("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");
        ReflectingActivity reflecting = new("Reflecting", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life");
        
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