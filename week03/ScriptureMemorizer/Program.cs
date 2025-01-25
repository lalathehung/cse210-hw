//CSE210 W03 Scripture Memorizer Program by Lok Yin Arthur Leung
//Creativity: I have added a list of scriptures for the users to choose (line 10-14)
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> scriptures = new List<Scripture>
        {
            new Scripture(new Reference("Proverbs", "3", "5-6"), "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."),
            new Scripture(new Reference("John", "3", "16"), "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."),
            new Scripture(new Reference("Philippians", "4", "13"), "I can do all things through Christ which strengtheneth me.")
        };

        Console.WriteLine("Select a scripture to memorize:");
        for (int i = 0; i < scriptures.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {scriptures[i].GetReference()}");
        }

        Console.Write("Enter the number of your choice: ");
        int choice = int.Parse(Console.ReadLine());
        Scripture selectedScripture = scriptures[choice - 1];

        ScriptureMemorizer scriptureMemorizer = new ScriptureMemorizer(selectedScripture);

        string userInput = "";
        while (userInput != "quit" && scriptureMemorizer.HasWordsLeft())
        {
            Console.Clear();
            Console.WriteLine($"{selectedScripture.GetReference()}: {scriptureMemorizer.ToString()}");
            Console.WriteLine("\nPress Enter to continue or type 'quit' to exit.");
            userInput = Console.ReadLine();
            if (userInput != "quit")
            {
                scriptureMemorizer.RemoveWordsFromText();
            }
        }
        Console.Clear();
        Console.WriteLine($"{selectedScripture.GetReference()}: {scriptureMemorizer.ToString()}");
        Console.WriteLine("\nGood job! You've completed the scripture.");
    }
}