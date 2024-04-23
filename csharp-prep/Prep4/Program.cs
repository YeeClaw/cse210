using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbersList = GetNumbers();
        
        Console.WriteLine($"The sum is: {numbersList.Sum()}");
        Console.WriteLine($"The average is: {numbersList.Average()}");
        Console.WriteLine($"The largest number is: {numbersList.Max()}");
        Console.WriteLine($"The smallest positive number is: {MinPositive(numbersList)}");

        List<int> sortedList = numbersList.OrderBy(n => n).ToList();
        Console.WriteLine("The numbers in ascending order are:");
        foreach (int number in sortedList)
        {
            Console.WriteLine(number);
        }
    }

    static List<int> GetNumbers()
    {
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        int number;

        do
        {
            Console.Write("Enter a number: ");
            number = int.Parse(Console.ReadLine());
            if (number == 0)
            {
                break;
            }

            numbers.Add(number);
        } while (number != 0);

        return numbers;
    }

    static int MinPositive(List<int> numbers)
    // As far as I'm aware, there isn't a built-in method for this in C#. Very specific use case.
    {
        int min = numbers.Max();
        foreach (int number in numbers)
        {
            if (number > 0 && number < min)
            {
                min = number;
            }
        }

        return min;
    }
}