using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mindfulness
{
    public class ListingActivity : Activity
    {
        private int _count = 0;
        private List<string> _prompts;
        private List<string> _answers = [];

        public ListingActivity(string name, string description, int duration, List<string> prompts) : base(name, description, duration)
        {
            _prompts = prompts;
        }

        public void SetDuration(int duration)
        {
            Duration = duration;
        }

        public string GetRandomPrompt()
        {
            Random random = new Random();
            int length = _prompts.Count;
            int randomIndex = random.Next(0, length);
            string randomPrompt = _prompts[randomIndex];
            return randomPrompt;
        }
        public void GetListFromUser()
        {
            Console.Write(">");
            string answer = Console.ReadLine();
            _answers.Add(answer);
        }

        public void Run()
        {
            DisplayStartingMessage();
            Console.WriteLine("List as many responses as you can to the following prompt:");
            string prompt = GetRandomPrompt();
            Console.WriteLine($"--- {prompt}--- ");
            Console.Write($"You may begin in ");
            ShowCountDown(5);
            Console.WriteLine("");

            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(Duration);
            while (DateTime.Now < endTime)
            {
                GetListFromUser();
            }
            int length = _answers.Count;
            _count = length;
            Console.WriteLine($"\nYou listed {_count} items!");
            DisplayEndingMessage();
        }
    }
}