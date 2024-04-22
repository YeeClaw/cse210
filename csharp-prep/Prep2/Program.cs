using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            int currentGrade = GetGrade();
            string currentLetterGrade = GetLetterGrade(currentGrade);
            string prefix = GetPrefix(currentGrade);

            Console.WriteLine($"\nYour grade is a/an {currentLetterGrade}{prefix}.");
        }
        
    }

    static int GetGrade()
    {
        Console.Write("What is your grade as a percentage? ");
        int grade = int.Parse(Console.ReadLine());

        return grade;
    }

    static string GetLetterGrade(int grade)
    {
        if (grade >= 90)
        {
            return "A";
        }
        else if (grade >= 80)
        {
            return "B";
        }
        else if (grade >= 70)
        {
            return "C";
        }
        else if (grade >= 60)
        {
            return "D";
        }
        else
        {
            return "F";
        }
    }

    static string GetPrefix(int grade)
    {
        int lastDigit = grade % 10;

        if (lastDigit >= 7 && grade < 97 && grade >= 60)
        {
            return "+";
        }
        else if (lastDigit < 3 && grade < 97 && grade >= 60)
        {
            return "-";
        }
        else
        {
            return "";
        }
    }
}