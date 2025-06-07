using System;

namespace ScriptureMemorizer
{
    class Program
    {
        /*
        * Exceeding Requirements:
        * 1. The program implements a smart word hiding algorithm that only hides words that haven't been hidden yet,
        *    making the memorization process more effective.
        * 2. The program handles both single verse and verse range references (e.g., "John 3:16" and "Proverbs 3:5-6").
        * 3. The program provides a clean user interface with clear instructions and proper spacing.
        * 4. The program gracefully handles the quit command at any point during the memorization process.
        */
        static void Main(string[] args)
        {
            // Create a scripture with a single verse reference
            Reference reference = new Reference("John", 3, 16);
            string text = "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.";
            Scripture scripture = new Scripture(reference, text);

            // Main program loop
            while (!scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nPress Enter to continue or type 'quit' to finish:");
                
                string input = Console.ReadLine();
                if (input.ToLower() == "quit")
                {
                    break;
                }

                // Hide 3 random words each time
                scripture.HideRandomWords(3);
            }

            // Final display
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nAll words are now hidden. Press Enter to exit.");
            Console.ReadLine();
        }
    }
}