using System;

public static class Program // Class extensions need to hail from static classes
{
    static void Main(string[] args)
    {
        string first_name = GetName().Capitalize();
        string last_name = GetName("last").Capitalize();

        Console.WriteLine($"\nYour name is {last_name}, {first_name} {last_name}.");
    }

    static string GetName(string name_type = "first")
    {
        Console.Write($"What is your {name_type} name? ");
        string name = Console.ReadLine();

        return name;
    }

    public static string Capitalize(this string input) // The 'this' keyword makes this an extension method and lets it be called on all strings
    {
        char proper_first_letter = input[0].ToString().ToUpper()[0]; 
        // The [0] seems redundant since the string is only 1 character long, but it's necessary to convert the string to a char
        
        return proper_first_letter + input[1..];
    }

    // Something interesting to note is that when C# is compiled, it reviews the code 2 times. The first time to define symbols
    // such as classes, methods, and variables. The second time to actually compile the code. This is why you can call methods
    // "out of order". The compiler knows what you're talking about because it's already seen the method definition.
}