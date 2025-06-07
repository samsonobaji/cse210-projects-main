using System;

/*
 * Enhanced Features:
 * 1. Added mood tracking to each entry to help users reflect on their emotional state
 * 2. Implemented a word count feature to encourage meaningful entries
 * 3. Added a search function to find entries by keyword
 * 4. Enhanced prompts with more variety (8 total prompts)
 * 5. Added entry statistics (total entries, average word count)
 * 6. Improved file format with JSON storage for better data integrity
 * 7. Added error handling for file operations
 */

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Search");
            Console.WriteLine("6. Statistics");
            Console.WriteLine("7. Quit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteNewEntry(journal);
                    break;
                case "2":
                    journal.DisplayAll();
                    break;
                case "3":
                    LoadJournal(journal);
                    break;
                case "4":
                    SaveJournal(journal);
                    break;
                case "5":
                    SearchJournal(journal);
                    break;
                case "6":
                    journal.DisplayStatistics();
                    break;
                case "7":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void WriteNewEntry(Journal journal)
    {
        string prompt = journal.GetRandomPrompt();
        Console.WriteLine($"\n{prompt}");
        Console.Write("> ");
        string response = Console.ReadLine();
        
        Console.Write("How are you feeling today? (optional, press Enter to skip): ");
        string mood = Console.ReadLine();
        
        string date = DateTime.Now.ToString("MM/dd/yyyy");
        Entry entry = new Entry(date, prompt, response, mood);
        journal.AddEntry(entry);
        
        Console.WriteLine($"Entry saved! Word count: {entry._wordCount}");
    }

    static void SaveJournal(Journal journal)
    {
        Console.Write("What is the filename? ");
        string filename = Console.ReadLine();
        journal.SaveToFile(filename);
        Console.WriteLine("Journal saved successfully!");
    }

    static void LoadJournal(Journal journal)
    {
        Console.Write("What is the filename? ");
        string filename = Console.ReadLine();
        journal.LoadFromFile(filename);
        Console.WriteLine("Journal loaded successfully!");
    }

    static void SearchJournal(Journal journal)
    {
        Console.Write("Enter search term: ");
        string keyword = Console.ReadLine();
        var results = journal.SearchEntries(keyword);
        
        if (results.Count == 0)
        {
            Console.WriteLine("No entries found matching your search.");
            return;
        }

        Console.WriteLine($"\nFound {results.Count} matching entries:");
        foreach (var entry in results)
        {
            Console.WriteLine(entry.GetDisplayString());
        }
    }
}