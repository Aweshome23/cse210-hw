using System;
using System.Net;
using System.Runtime.CompilerServices;

public class Journal
{

    List<Entry> _entries = new List<Entry>();
    List<string> prompts = new List<string>
    {
        "What are myr favorite things that happened today?",
        "What activities did I do today?",
        "What did I get done today?",
        "How have I seen the Lord today?",
        "What did I do with my family today?"
    };

    Random random = new Random();

    public void AddEntry()
    {

    int index = random.Next(prompts.Count);
    string selectedPrompt = prompts[index];

    Console.WriteLine($"{selectedPrompt}");
    string response = Console.ReadLine();
    string date = DateTime.Now.ToShortDateString();
    Entry newEntry = new Entry(date, selectedPrompt, response);
    _entries.Add(newEntry);
    }

    public void DisplayJournal()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        List<string> lines = new List<string>();

        foreach (Entry entry in _entries)
        {
            string line = $"{entry._date}|{entry._prompt}|{entry._response}";
            lines.Add(line);
        }

        File.WriteAllLines(filename, lines);
        Console.WriteLine("Journal saved successfully!\n");
    }

    public void LoadFromFile(string filename)
    {
        string[] lines = File.ReadAllLines(filename);

        _entries.Clear();

        foreach (string line in lines)
        {
            string[] parts = line.Split('|');

            string date = parts[0];
            string prompt = parts[1];
            string response = parts[2];

            Entry loadedEntry = new Entry(date, prompt, response);
            _entries.Add(loadedEntry);
        }

        Console.WriteLine("Journal loaded successfully!\n");
    }
}