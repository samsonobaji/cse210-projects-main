using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    public class GoalManager
    {
        private List<Goal> _goals;
        private int _score;

        public GoalManager()
        {
            _goals = new List<Goal>();
            _score = 0;
        }

        public void AddGoal(Goal goal)
        {
            _goals.Add(goal);
        }

        public void RecordEvent(int goalIndex)
        {
            if (goalIndex >= 0 && goalIndex < _goals.Count)
            {
                _score += _goals[goalIndex].RecordEvent();
            }
        }

        public void DisplayGoals()
        {
            Console.WriteLine("\nThe goals are:");
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetDisplayString()}");
            }
        }

        public void DisplayScore()
        {
            Console.WriteLine($"\nYou have {_score} points.");
        }

        public void SaveGoals(string filename)
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                outputFile.WriteLine(_score);
                foreach (Goal goal in _goals)
                {
                    outputFile.WriteLine(goal.GetStringRepresentation());
                }
            }
        }

        public void LoadGoals(string filename)
        {
            if (File.Exists(filename))
            {
                string[] lines = File.ReadAllLines(filename);
                _score = int.Parse(lines[0]);

                for (int i = 1; i < lines.Length; i++)
                {
                    string[] parts = lines[i].Split(":");
                    string goalType = parts[0];
                    string[] goalData = parts[1].Split(",");

                    switch (goalType)
                    {
                        case "SimpleGoal":
                            SimpleGoal simpleGoal = new SimpleGoal(
                                goalData[0], goalData[1], int.Parse(goalData[2]));
                            if (bool.Parse(goalData[3])) simpleGoal.RecordEvent();
                            _goals.Add(simpleGoal);
                            break;

                        case "EternalGoal":
                            _goals.Add(new EternalGoal(
                                goalData[0], goalData[1], int.Parse(goalData[2])));
                            break;

                        case "ChecklistGoal":
                            ChecklistGoal checklistGoal = new ChecklistGoal(
                                goalData[0], goalData[1], int.Parse(goalData[2]),
                                int.Parse(goalData[4]), int.Parse(goalData[3]));
                            for (int j = 0; j < int.Parse(goalData[5]); j++)
                            {
                                checklistGoal.RecordEvent();
                            }
                            _goals.Add(checklistGoal);
                            break;
                    }
                }
            }
        }

        public int GetGoalCount()
        {
            return _goals.Count;
        }
    }
} 