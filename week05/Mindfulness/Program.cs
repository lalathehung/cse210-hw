using System;
using Mindfulness;

// I exceeded the requirements by adding a Gratitude Visualization Activity that asks you how many prompts you would like to meditate on and rings a chime each time a new prompt appears.
class Program
{
    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n-----MENU-----");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.WriteLine("\nWhat would you like to do? ");
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                BreathingActivity breathingActivity = new BreathingActivity("Breathing", "This activity will help you relax by walking you through breathing in and out slowly.\nClear your mind and focus your breathing", 5);
                breathingActivity.Run();
            }
            else if (choice == "2")
            {
                ReflectionActivity reflectionActivity = new ReflectionActivity("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.", 5, ["Think of a time when you stood up for someone else.", "Think of a time when you did something really difficult.", "Think of a time when you helped someone in need.", "Think of a time when you did something truly selfless.", "Think of a time when you worked really hard toward a goal and achieved it.", "Think of a time when you had to be brave, even though you were scared.", "Think of a time when you forgave someone, even when it was hard.", "Think of a time when you made a mistake but learned something valuable from it.", "Think of a time when you received unexpected kindness from someone.", "Think of a time you admitted you were wrong."], ["Why was this experience meaningful to you?", "What would you say is the biggest takeaway from this experience?", "How might this experience shape your future decisions or actions?", "How has this experience changed your perspective on yourself or the world around you?", "If you were to share this experience with someone else, what advice would you give them?", "What skills or qualities did you use that helped make this experience successful?", "How does this experience connect to your personal values or goals?", "If you could go back and change anything about this experience, what would it be and why?", "What surprised you the most about this experience?", "Did anyone else play a role in this experience? How did they influence it?", "What challenges did you face during this experience, and how did you overcome them?", "Have you ever done anything like this before?", "How did you get started?", "How did you feel when it was complete?", "What made this time different than other times when you were not as successful?", "What is your favorite thing about this experience?", "What could you learn from this experience that applies to other situations?", "What did you learn about yourself through this experience?", "How can you keep this experience in mind in the future?"]);
                reflectionActivity.Run();
            }
            else if (choice == "3")
            {
                ListingActivity listingActivity = new ListingActivity("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", 5, ["Who are people that you appreciate?", "What are personal strengths of yours?", "Who are people that you have helped this week?", "When have you felt the Holy Ghost this month?", "Who are some of your personal heroes?"]);
                listingActivity.Run();

            }
            
            else if (choice == "4")
            {
                Console.WriteLine("\nGoodbye!\n");
                running = false;
            }
        }
    }
}