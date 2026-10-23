using System;
using System.Collections.Generic;

public class ListeningActivity : Activity
{
    
    public ListeningActivity()
    {
        SetDetails("Listening Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
    }

    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private Random _random = new Random();

    public void Run()
    {

        DisplayStartingMessage();

        string prompt = _prompts[_random.Next(_prompts.Count)];

        Console.WriteLine("\nList as many responses you can to the following prompt:");
        Console.WriteLine($" --- {prompt} ---");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine("");

        List<string> userItems = new List<string>();

        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(GetDuration());

        while(DateTime.Now < futureTime)
        {
            Console.Write("> ");
            string input = Console.ReadLine();

            userItems.Add(input);
        }

        Console.WriteLine($"You listed {userItems.Count} items!");

        DisplayEndingMessage();
    }

}
