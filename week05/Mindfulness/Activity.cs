using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mindfulness
{
    public class Activity
    {
        private string _name;
        private string _description;
        private int _duration;

        public int Duration
        {
            get { return _duration; }
            set { _duration = value; }
        }

        public Activity(string name, string description, int duration)
        {
            _name = name;
            _description = description;
            _duration = duration;
        }

         public void ShowCountDown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                if(i<10){
                    Console.Write(i);
                    Thread.Sleep(1000);
                    Console.Write("\b \b");
                }else if(i > 10){
                    Console.Write(i);
                    Thread.Sleep(1000);
                    Console.Write("\b \b\b \b");
                }else if(i>99){
                    Console.Write(i);
                    Thread.Sleep(1000);
                    Console.Write("\b \b\b \b\b \b");
                }else if(i>999){
                    Console.Write("\b \b\b \b\b \b\b \b");

                }
            }
        }

        public void ShowSpinner(int seconds)
        {
            List<string> animationStrings = ["Oooooo", "OOoooo", "OOOooo", "oOOOoo", "ooOOOo", "oooOOO", "ooooOO"];
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(seconds);

            while (DateTime.Now < endTime)
            {
                foreach (string s in animationStrings)
                {
                    Console.Write(s);
                    Thread.Sleep(100);
                    Console.Write("\b \b\b \b\b \b\b \b\b \b\b \b");
                }
            }
        }

        public void DisplayStartingMessage()
        {
            Console.Clear();
            Console.WriteLine($"\nWelcome to the {_name} Activity.\n");
            Console.WriteLine($"{_description}.\n");
            Console.Write("How many seconds would you like your session to be? ");
            string input = Console.ReadLine();
            _duration = int.Parse(input);
            Console.Clear();
            Console.WriteLine("Get ready...");
            ShowSpinner(3);
        }

        public void DisplayEndingMessage()
        {
            Console.WriteLine($"Well done!");
            ShowSpinner(3);
            Console.WriteLine($"You have completed another {_duration} seconds of the {_name} Activity.\n");
            ShowSpinner(3);

        }
    }
}