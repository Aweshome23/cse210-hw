using System;

public class GameEngine
{
    public void Run()
    {
        Console.WriteLine("Welcome to the Text RPG Engine!");
        Console.WriteLine("1. Start Adventure");
        Console.Write("Choose an option: ");
        string choice = Console.ReadLine();

        if (choice == "1")
        {
            Console.WriteLine("Journeying begins soon...");
        }
    }
}