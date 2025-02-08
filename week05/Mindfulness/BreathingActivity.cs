using System;
using System.Collections.Generic;
using System.Threading;

namespace Mindfulness
{
    public class BreathingActivity : Activity
    {
        public BreathingActivity(string name, string description, int duration) 
            : base(name, description, duration)
        {
        }

        public void SetDuration(int duration)
        {
            Duration = duration;
        }

        public void Run()
        {
            List<string> breathList = new List<string> { "Breathe in...", "Now breathe out..." };

            DisplayStartingMessage();
            ShowSpinner(2);
            Thread.Sleep(1000);

            DateTime endTime = DateTime.Now.AddSeconds(Duration);

            while (DateTime.Now < endTime)
            {
                Console.WriteLine("\n" + breathList[0]); // "Breathe in..."
                ShowCountDown(4); // Simulates slow inhale
                
                Console.WriteLine("\n" + breathList[1]); // "Now breathe out..."
                ShowCountDown(6); // Simulates longer exhale
            }

            DisplayEndingMessage();
        }
    }
}
