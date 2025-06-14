using System;
using System.Threading;

namespace Mindfulness
{
    public class BreathingActivity : Activity
    {
        public BreathingActivity() : base(
            "Breathing",
            "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing."
        )
        {
        }

        public override void Run()
        {
            Start();

            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(_duration);

            while (DateTime.Now < endTime)
            {
                Console.WriteLine();
                Console.Write("Breathe in...");
                ShowCountDown(4);
                Console.WriteLine();
                Console.Write("Breathe out...");
                ShowCountDown(6);
                Console.WriteLine();
            }

            End();
        }
    }
} 