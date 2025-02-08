using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mindfulness
{
    public class BreathingActivity : Activity
    {
        public BreathingActivity(string name, string description, int duration) : base(name, description, duration)
        {

        }
        public void SetDuration(int duration)
        {
            Duration = duration;
        }
        public void Run()
        {
            List<string> breathList = ["Breathe in...", "Now breathe out...\n",];

            DisplayStartingMessage();
            ShowSpinner(2);
            Thread.Sleep(1000);
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(Duration);

            while (DateTime.Now < endTime)
            {
                foreach (string breath in breathList)
                {
                    Console.WriteLine(breath);
                    ShowCountDown(3);
                    Thread.Sleep(500);
                }
            }
            DisplayEndingMessage();
        }
    }
}