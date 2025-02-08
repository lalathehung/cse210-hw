using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mindfulness
{
    public class ReflectionActivity : Activity
    {
        private List<string> _prompts;
        private List<string> _questions;

        public ReflectionActivity(string name, string description, int duration, List<string> prompts, List<string> questions) : base(name, description, duration)
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
            Random random = new Random();
            int length = _prompts.Count;
            int randomIndex = random.Next(0, length);
            string randomPrompt = _prompts[randomIndex];
            return randomPrompt;
        }
        public string GetRandomQuestion()
        {
            Random random = new Random();
            int length = _questions.Count;
            int randomIndex = random.Next(0, length);
            string randomQuestion = _questions[randomIndex];
            return randomQuestion;
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
            Console.WriteLine("When you have something in mind, press enter to continue.\n");
            string input = Console.ReadLine();

            if (input == "")
            {
                Console.Write("You may begin in: ");
                ShowCountDown(3);
                Console.Clear();

                DateTime startTime = DateTime.Now;
                TimeSpan elapsedTime = DateTime.Now - startTime;

                while (elapsedTime < TimeSpan.FromSeconds(Duration))
                {
                    foreach (string question in _questions)
                    {
                       if (elapsedTime >= TimeSpan.FromSeconds(Duration))
                {
                    break;
                }

                DisplayQuestion();
                ShowSpinner(5);
                Thread.Sleep(300);

                elapsedTime = DateTime.Now - startTime;
                    }
                }
            }
            DisplayEndingMessage();
        } //end of Run
    }
}