using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        bool running = true;

        while (running)
        {
            DisplayPlayerInfo();
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                CreateGoal();
            }
            else if (choice == "2")
            {
                ListGoalDetails();
            }
            else if (choice == "3")
            {
                SaveGoals();
            }
            else if (choice == "4")
            {
                LoadGoals();
            }
            else if (choice == "5")
            {
                RecordEvent();
            }
            else if (choice == "6")
            {
                running = false;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nYou have {_score} points.\n");
    }

    public void ListGoalNames()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {_goals[i].GetName()}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string typeChoice = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        string points = Console.ReadLine();

        if (typeChoice == "1")
        {
            SimpleGoal goal = new SimpleGoal(name, description, points);
            _goals.Add(goal);
        }
        else if (typeChoice == "2")
        {
            EternalGoal goal = new EternalGoal(name, description, points);
            _goals.Add(goal);
        }
        else if (typeChoice == "3")
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());

            ChecklistGoal goal = new ChecklistGoal(name, description, points, target, bonus);
            _goals.Add(goal);
        }
    }

    public void RecordEvent()
    {
        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < _goals.Count)
        {
            Goal goal = _goals[index];
            bool wasCompleteBefore = goal.IsComplete();
            
            goal.RecordEvent();
            int pointsEarned = int.Parse(goal.GetPoints());
            _score += pointsEarned;

            // Check if it's a checklist goal hitting its completion target for the bonus
            if (goal is ChecklistGoal checklistGoal)
            {
                if (!wasCompleteBefore && checklistGoal.IsComplete())
                {
                    int bonus = checklistGoal.GetBonus();
                    _score += bonus;
                    Console.WriteLine($"Congratulations! You have earned {pointsEarned} points plus a bonus of {bonus} points!");
                }
                else
                {
                    Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
                }
            }
            else
            {
                Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
            }

            Console.WriteLine($"You now have {_score} points.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            _score = int.Parse(lines[0]);
            _goals.Clear();

            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] parts = line.Split(":");
                string goalType = parts[0];
                string details = parts[1];
                string[] detailParts = details.Split(",");

                if (goalType == "SimpleGoal")
                {
                    string name = detailParts[0];
                    string description = detailParts[1];
                    string points = detailParts[2];
                    bool isComplete = bool.Parse(detailParts[3]);

                    SimpleGoal goal = new SimpleGoal(name, description, points, isComplete);
                    _goals.Add(goal);
                }
                else if (goalType == "EternalGoal")
                {
                    string name = detailParts[0];
                    string description = detailParts[1];
                    string points = detailParts[2];

                    EternalGoal goal = new EternalGoal(name, description, points);
                    _goals.Add(goal);
                }
                else if (goalType == "ChecklistGoal")
                {
                    string name = detailParts[0];
                    string description = detailParts[1];
                    string points = detailParts[2];
                    int bonus = int.Parse(detailParts[3]);
                    int target = int.Parse(detailParts[4]);
                    int amountCompleted = int.Parse(detailParts[5]);

                    ChecklistGoal goal = new ChecklistGoal(name, description, points, amountCompleted, target, bonus);
                    _goals.Add(goal);
                }
            }
        }
    }
}