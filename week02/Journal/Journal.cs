using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

public class Journal
{
    public List<Entry> _entries;
    private List<string> _prompts;

    public Journal()
    {
        _entries = new List<Entry>();
        _prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What was the most challenging thing I faced today?",
            "What am I grateful for today?",
            "What did I learn today that I want to remember?"
        };
    }

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries found.");
            return;
        }

        foreach (Entry entry in _entries)
        {
            Console.WriteLine(entry.GetDisplayString());
        }
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }

    public void SaveToFile(string filename)
    {
        try
        {
            string json = JsonSerializer.Serialize(_entries);
            File.WriteAllText(filename, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving journal: {ex.Message}");
        }
    }

    public void LoadFromFile(string filename)
    {
        try
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("File not found.");
                return;
            }

            string json = File.ReadAllText(filename);
            _entries = JsonSerializer.Deserialize<List<Entry>>(json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading journal: {ex.Message}");
        }
    }

    public List<Entry> SearchEntries(string keyword)
    {
        return _entries.Where(e => 
            e._response.ToLower().Contains(keyword.ToLower()) ||
            e._prompt.ToLower().Contains(keyword.ToLower()) ||
            e._mood.ToLower().Contains(keyword.ToLower())
        ).ToList();
    }

    public void DisplayStatistics()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries to analyze.");
            return;
        }

        double avgWordCount = _entries.Average(e => e._wordCount);
        var moodCounts = _entries
            .Where(e => !string.IsNullOrEmpty(e._mood))
            .GroupBy(e => e._mood)
            .ToDictionary(g => g.Key, g => g.Count());

        Console.WriteLine("\nJournal Statistics:");
        Console.WriteLine($"Total Entries: {_entries.Count}");
        Console.WriteLine($"Average Word Count: {avgWordCount:F1}");
        
        if (moodCounts.Any())
        {
            Console.WriteLine("\nMood Distribution:");
            foreach (var mood in moodCounts)
            {
                Console.WriteLine($"{mood.Key}: {mood.Value} entries");
            }
        }
    }
} 