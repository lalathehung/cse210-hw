using System;
using System.Collections.Generic;
using System.Threading;

namespace Mindfulness
{
    public class ReflectionActivity : Activity
    {
        private static Random _random = new Random(); // Static Random instance
        private List<string> _prompts;
        private List<string> _questions;

        public ReflectionActivity(string name, string description, int duration, List<string> prompts, List<string> questions) 
            : base(name, description, duration)
        {
            _prompts = prompts;
            _questions = questions;
        }

        public void SetDuration(int duration)
        {
            Duration = duration;
        }

        public string GetRandomPrompt()
        {
            return _prompts[_random.Next(_prompts.Count)];
        }

        public string GetRandomQuestion()
        {
            return _questions[_random.Next(_questions.Count)];
        }

        public void DisplayQuestion()
        {
            Console.WriteLine(GetRandomQuestion());
        }

        public void Run()
        {
            DisplayStartingMessage();

            Console.WriteLine("Consider the following prompt: ");
            Console.WriteLine($"--- {GetRandomPrompt()} ---");
            Console.WriteLine("When you have something in mind, press Enter to continue.\n");
            Console.ReadLine();

            Console.Write("You may begin in: ");
            ShowCountDown(3);
            Console.Clear();

            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(Duration);

            while (DateTime.Now < endTime)
            {
                DisplayQuestion();
                ShowSpinner(5);

                // Ensure the loop doesn't run beyond the time limit
                if (DateTime.Now >= endTime) 
                    break;
            }

            DisplayEndingMessage();
        }
    }
}
