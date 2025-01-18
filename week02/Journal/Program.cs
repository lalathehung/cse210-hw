//CSE210 W02 Journal by Lok Yin Arthur Leung
//Creativity: I have added the total number of entries to the saved file for better tracking;
//Creativity: I have added 15 extra prompts.
using System;

namespace DailyJournal
{
    class Program
    {
        static void Main(string[] args)
        {
            Journal journal = new Journal();

            List<string> prompts = new List<string>
            {
                "What is one thing you accomplished today that you are proud of? ",
                "Who made a positive impact on your day, and how did they do it? ",
                "What is one thing you learned today that you want to remember? ",
                "What was the most peaceful moment of your day? ",
                "How did you show kindness to someone else today? ",
                "What was a small but meaningful victory you had today? " ,
                "What challenged your patience today, and how did you handle it? ",
                "What is something you are grateful for that you might have taken for granted? ",
                "If you could relive one moment from today, what would it be and why? ",
                "How did you take care of yourself physically or emotionally today? ",
                "What made you laugh or brought you joy today? ",
                "How did you feel inspired or motivated today? ",
                "Was there a moment today where you felt particularly connected to someone else? ",
                "What is one thing you wish you could improve or do differently tomorrow? ",
                "How did you handle stress or a difficult situation today? ",
                "What made you feel creative or innovative today? ",
                "How did you feel our Havenly Father loved you today? ",
                "What did you want to tell our Heavenly Father? ",
                "How did you feel about the decisions you made today? ",
                "What are you going to do tomorrrow to improve yourself? ",
            };

            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("\n===Welcome to the Journal Program!===");
                Console.WriteLine("Please Select one of the following choices:");
                Console.WriteLine("1. Write");
                Console.WriteLine("2. Display");
                Console.WriteLine("3. Save");
                Console.WriteLine("4. Load");
                Console.WriteLine("5. Quit");

                Console.WriteLine("\nWhat would you like to do? ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    //Write
                    case "1":
                        string prompt = GetRandomPrompt(prompts);
                        journal.AddEntry(prompt);
                        break;
                    //Display
                    case "2":
                        journal.DisplayEntries();
                        break;
                    //Save
                    case "3":
                        journal.SaveToFile();
                        break;
                    //Load
                    case "4":
                        journal.LoadFromFile();
                        break;
                    //Quit
                    case "5":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
            Console.WriteLine("Goodbye! See you later!");
        }

        static string GetRandomPrompt(List<string> prompts)
        {
            Random random = new Random();
            int index = random.Next(prompts.Count);
            return prompts[index];
        }
    }
}