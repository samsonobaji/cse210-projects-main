using System;
using System.Collections.Generic;

namespace ExerciseTracking
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a list of activities
            List<Activity> activities = new List<Activity>();

            // Create activities
            Running running = new Running(new DateTime(2022, 11, 3), 30, 3.0);
            Cycling cycling = new Cycling(new DateTime(2022, 11, 3), 30, 6.0);
            Swimming swimming = new Swimming(new DateTime(2022, 11, 3), 30, 20);

            // Add activities to the list
            activities.Add(running);
            activities.Add(cycling);
            activities.Add(swimming);

            // Display activity summaries
            foreach (Activity activity in activities)
            {
                Console.WriteLine(activity.GetSummary());
            }
        }
    }
}