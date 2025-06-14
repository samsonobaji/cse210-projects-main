using System;

namespace EternalQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            GoalManager goalManager = new GoalManager();
            string filename = "goals.txt";

            // Load existing goals if available
            goalManager.LoadGoals(filename);

            while (true)
            {
                Console.WriteLine("\nMenu Options:");
                Console.WriteLine("  1. Create New Goal");
                Console.WriteLine("  2. List Goals");
                Console.WriteLine("  3. Save Goals");
                Console.WriteLine("  4. Load Goals");
                Console.WriteLine("  5. Record Event");
                Console.WriteLine("  6. Quit");
                Console.Write("Select a choice from the menu: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        CreateNewGoal(goalManager);
                        break;
                    case "2":
                        goalManager.DisplayGoals();
                        goalManager.DisplayScore();
                        break;
                    case "3":
                        goalManager.SaveGoals(filename);
                        Console.WriteLine("Goals saved successfully!");
                        break;
                    case "4":
                        goalManager.LoadGoals(filename);
                        Console.WriteLine("Goals loaded successfully!");
                        break;
                    case "5":
                        RecordEvent(goalManager);
                        break;
                    case "6":
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void CreateNewGoal(GoalManager goalManager)
        {
            Console.WriteLine("The types of Goals are:");
            Console.WriteLine("  1. Simple Goal");
            Console.WriteLine("  2. Eternal Goal");
            Console.WriteLine("  3. Checklist Goal");
            Console.Write("Which type of goal would you like to create? ");

            string choice = Console.ReadLine();
            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine();
            Console.Write("What is a short description of it? ");
            string description = Console.ReadLine();
            Console.Write("What is the amount of points associated with this goal? ");
            int points = int.Parse(Console.ReadLine());

            Goal goal = null;
            switch (choice)
            {
                case "1":
                    goal = new SimpleGoal(name, description, points);
                    break;
                case "2":
                    goal = new EternalGoal(name, description, points);
                    break;
                case "3":
                    Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                    int target = int.Parse(Console.ReadLine());
                    Console.Write("What is the bonus for accomplishing it that many times? ");
                    int bonus = int.Parse(Console.ReadLine());
                    goal = new ChecklistGoal(name, description, points, target, bonus);
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    return;
            }

            goalManager.AddGoal(goal);
            Console.WriteLine("Goal added successfully!");
        }

        static void RecordEvent(GoalManager goalManager)
        {
            if (goalManager.GetGoalCount() == 0)
            {
                Console.WriteLine("No goals available to record events for.");
                return;
            }

            goalManager.DisplayGoals();
            Console.Write("Which goal did you accomplish? ");
            int goalIndex = int.Parse(Console.ReadLine()) - 1;
            goalManager.RecordEvent(goalIndex);
            goalManager.DisplayScore();
        }
    }
}