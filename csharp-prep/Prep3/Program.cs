using System;

class Program
{
    static void Main(string[] args)
    {
        int guess = 0;

        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 100);

        while (guess != magicNumber)
        {
        Console.Write("What is your guess? ");
        string userInput = Console.ReadLine();
        guess = int.Parse(userInput);

        if (guess > magicNumber)
        {
            Console.WriteLine("Lower");
        }
        else if (guess < magicNumber)
        {
            Console.WriteLine("Higher");
        }
        else
        {
            Console.WriteLine("Congrats you guessed it!");
        }
        }
        
    }
}