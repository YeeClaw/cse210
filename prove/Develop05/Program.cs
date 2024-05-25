using System;

class Program
{
    /*
     * What I did to show creativity for this project lies mostly in areas that you cannot see. I took the challenge of
     * creating a saving method that would serialize the entire GoalManager object and save it into an XML file. This
     * approach makes the file saving and loading system very flexible, as it can be easily expanded to save and load
     * any object that can be serialized. This is a very powerful tool that can be used in many different projects.
     */
    static void Main(string[] args)
    {
        GoalManager manager = new();
        manager.Start();
    }
}