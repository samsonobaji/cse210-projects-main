using System;
using System.Collections.Generic;
using System.Threading;

namespace Mindfulness
{
    public class ListingActivity : Activity
    {
        private List<string> _prompts;
        private List<string> _items;

        public ListingActivity() : base(
            "Listing",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area."
        )
        {
            _prompts = new List<string>
            {
                "Who are people that you appreciate?",
                "What are personal strengths of yours?",
                "Who are people that you have helped this week?",
                "When have you felt the Holy Ghost this month?",
                "Who are some of your personal heroes?"
            };

            _items = new List<string>();
        }

        public override void Run()
        {
            Start();

            // Select a random prompt
            Random random = new Random();
            string prompt = _prompts[random.Next(_prompts.Count)];
            Console.WriteLine("\nList as many responses as you can to the following prompt:");
            Console.WriteLine($"\n--- {prompt} ---\n");
            Console.Write("You may begin in: ");
            ShowCountDown(5);

            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(_duration);

            Console.WriteLine("\nBegin listing items:");
            while (DateTime.Now < endTime)
            {
                Console.Write("> ");
                string item = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(item))
                {
                    _items.Add(item);
                }
            }

            Console.WriteLine($"\nYou listed {_items.Count} items!");
            End();
        }
    }
} 