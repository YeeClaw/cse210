using System;
using Foundation2;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new("123 Main St", "Anytown", "AS", "12345");
        Address address2 = new("456 Elm St", "Othertown", "AS", "54321");
        Address address3 = new("789 Oak St", "Thirdtown", "AS", "15243");
        
        Lecture lecture = new(
            "Space-time", 
            "A lecture on the fabric of the universe", 
            new DateTime(1824, 6, 4), 
            address1, 
            "Dr. Who", 
            "100"
            );
        Reception reception = new(
            "Austin & Hailey",
            "For time and all eternity",
            new(2024, 05, 04),
            address2,
            new List<Person>()
            {
                new("Austin", "Colt"),
                new("Hailey", "Colt"),
                new("John", "Doe"),
                new("Jane", "Doe")
            }
        );
        OutdoorGathering outdoorGathering = new(
            "Picnic",
            "A gathering for food and fun",
            new(2024, 07, 04),
            address3,
            "Sunny"
        );
        
        Console.Clear();
        Console.WriteLine(lecture.GetFullDetails());
        Console.WriteLine();
        Console.WriteLine(lecture.GetStandardDetails());
        Console.WriteLine();
        Console.WriteLine(lecture.GetShortDescription());
        Console.WriteLine();
        Console.WriteLine(reception.GetFullDetails());
        Console.WriteLine();
        Console.WriteLine(reception.GetStandardDetails());
        Console.WriteLine();
        Console.WriteLine(reception.GetShortDescription());
        Console.WriteLine();
        reception.RegisterPerson(new("Logan", "Ondrak"));
        Console.WriteLine(reception.GetFullDetails());
        Console.WriteLine();
        Console.WriteLine(outdoorGathering.GetFullDetails());
        Console.WriteLine();
        outdoorGathering.UpdateWeather("Cloudy");
        Console.WriteLine(outdoorGathering.GetFullDetails());
        Console.WriteLine();
        Console.WriteLine(outdoorGathering.GetShortDescription());
        Console.WriteLine();
        Console.WriteLine(outdoorGathering.GetStandardDetails());
    }
}