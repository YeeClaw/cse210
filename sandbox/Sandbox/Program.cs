namespace Sandbox; // I don't know why these aren't taught

using System;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Hello Sandbox World!");

        string[] frames = File.ReadAllText("../../../frames.txt").Split("&");

        TextAnimation diamondThing = new(10, frames);

        await diamondThing.Play();
        
        Console.WriteLine("Goodbye Sandbox World!");
    }
    
}