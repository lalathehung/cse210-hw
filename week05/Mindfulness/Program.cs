using System;
using System.IO;
using System.Collections.Generic;
using Mindfulness;
//Creativity: I have ccreated a log of how many times activities were performed.
class Program
{
    static Dictionary<string, int> activityCounts = new Dictionary<string, int>()
    {
        { "Breathing", 0 },
        { "Reflection", 0 },
        { "Listing", 0 }
    };

    static string logFilePath = "activity_log.txt";

    static void Main(string[] args)
    {
        LoadActivityCounts(); // Load past session data

        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("\n----- MENU -----");
            Console.WriteLine($"1. Breathing Activity ({activityCounts["Breathing"]} completed)");
            Console.WriteLine($"2. Reflection Activity ({activityCounts["Reflection"]} completed)");
            Console.WriteLine($"3. Listing Activity ({activityCounts["Listing"]} completed)");
            Console.WriteLine("4. Quit");
            Console.Write("\nWhat would you like to do? ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity breathingActivity = new BreathingActivity("Breathing", 
                    "This activity will help you relax by walking you through breathing in and out slowly.\nClear your mind and focus your breathing", 5);
                breathingActivity.Run();
                UpdateActivityCount("Breathing");
            }
            else if (choice == "2")
            {
                ReflectionActivity reflectionActivity = new ReflectionActivity("Reflection", 
                    "This activity will help you reflect on times in your life when you have shown strength and resilience.", 
                    5, 
                    new List<string> { "Think of a time when you stood up for someone else.", "Think of a time when you did something really difficult." }, 
                    new List<string> { "Why was this experience meaningful to you?", "What did you learn about yourself?" });
                reflectionActivity.Run();
                UpdateActivityCount("Reflection");
            }
            else if (choice == "3")
            {
                ListingActivity listingActivity = new ListingActivity("Listing", 
                    "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", 
                    5, 
                    new List<string> { "Who are people that you appreciate?", "What are personal strengths of yours?" });
                listingActivity.Run();
                UpdateActivityCount("Listing");
            }
            else if (choice == "4")
            {
                Console.WriteLine("\nGoodbye! See you again soon!\n");
                running = false;
            }
        }
    }

    static void UpdateActivityCount(string activityName)
    {
        activityCounts[activityName]++;
        SaveActivityCounts();
    }

    static void SaveActivityCounts()
    {
        using (StreamWriter writer = new StreamWriter(logFilePath))
        {
            foreach (var entry in activityCounts)
            {
                writer.WriteLine($"{entry.Key}:{entry.Value}");
            }
        }
    }

    static void LoadActivityCounts()
    {
        if (File.Exists(logFilePath))
        {
            foreach (string line in File.ReadAllLines(logFilePath))
            {
                string[] parts = line.Split(':');
                if (parts.Length == 2 && int.TryParse(parts[1], out int count))
                {
                    activityCounts[parts[0]] = count;
                }
            }
        }
    }
}
