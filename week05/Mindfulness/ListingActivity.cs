using System;
using System.Collections.Generic;
using System.Threading;

namespace Mindfulness
{
    public class ListingActivity : Activity
    {
        private static Random _random = new Random(); // Static Random instance
        private List<string> _prompts;
        private List<string> _answers = new List<string>();

        public ListingActivity(string name, string description, int duration, List<string> prompts) 
            : base(name, description, duration)
        {
            _prompts = prompts;
        }

        public void SetDuration(int duration)
        {
            Duration = duration;
        }

        public string GetRandomPrompt()
        {
            return _prompts[_random.Next(_prompts.Count)];
        }

        public void GetListFromUser()
        {
            Console.Write("> ");
            string answer = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(answer))
            {
                _answers.Add(answer);
            }
        }

        public void Run()
        {
            DisplayStartingMessage();
            
            Console.WriteLine("List as many responses as you can to the following prompt:");
            string prompt = GetRandomPrompt();
            Console.WriteLine($"\n--- {prompt} ---\n");
            Console.Write("You may begin in: ");
            ShowCountDown(5);
            Console.WriteLine();

            DateTime endTime = DateTime.Now.AddSeconds(Duration);

            while (DateTime.Now < endTime)
            {
                GetListFromUser();
            }

            Console.WriteLine($"\nYou listed {_answers.Count} items!");
            DisplayEndingMessage();
        }
    }
}
