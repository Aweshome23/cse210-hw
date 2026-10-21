using System;
using System.Xml.Serialization;

class Program
{
    
    static void Main(string[] args)
    {
        Journal theJournal = new Journal();
        int choice = 0;

        while (choice != 5)
        {
        Console.WriteLine("Please select one of the following choices:");
        Console.WriteLine("1. Write");
        Console.WriteLine("2. Display");
        Console.WriteLine("3. Load");
        Console.WriteLine("4. Save");
        Console.WriteLine("5. Quit");
        Console.Write("What would you like to do? ");
        choice = int.Parse(Console.ReadLine());
        

        if (choice == 1)
        {
            theJournal.AddEntry();
        }
        else if (choice == 2)
        {
            theJournal.DisplayJournal();
        }
        else if (choice == 3)
        {
            Console.WriteLine("Enter filename to load: ");
            string loadFile = Console.ReadLine();
            theJournal.LoadFromFile(loadFile);
        }
        else if (choice == 4)
        {
            Console.WriteLine("Enter filename to save: ");
            string saveFile = Console.ReadLine();
            theJournal.SaveToFile(saveFile);
        }
        else if (choice == 5)
        {
            Console.WriteLine("Goodbye");
        }
        else
        {
            Console.WriteLine("Invalid Choice. Please try again");
        }
        }
    }
}