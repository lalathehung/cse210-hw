using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise Tracking Project.");

        List<Activity> activities = new List<Activity>();
        string menu = "\n1. Running | 2. Cycling | 3. Swimming | 4. Get Track Summary | 5. Quit";
        int response = 0;

        do
        {
            Console.WriteLine(menu);
            Console.Write("\nChoose your preferred option (enter number): ");
            string input = Console.ReadLine();
            Console.WriteLine("");

            if (int.TryParse(input, out response))
            {
                switch (response)
                {
                    case 1:
                        Running running = new Running();
                        running.StartRunning();
                        activities.Add(running);
                        Console.WriteLine("\n Running activity added successfully!\n");
                        break;

                    case 2:
                        Cycling cycling = new Cycling();
                        cycling.StartCycling();
                        activities.Add(cycling);
                        Console.WriteLine("\n Cycling activity added successfully!\n");
                        break;

                    case 3:
                        Swimming swimming = new Swimming();
                        swimming.StartSwimming();
                        activities.Add(swimming);
                        Console.WriteLine("\n Swimming activity added successfully!\n");
                        break;

                    case 4:
                        if (activities.Count == 0)
                        {
                            Console.WriteLine("\n⚠ No activities recorded yet. Add an activity first!\n");
                        }
                        else
                        {
                            Console.WriteLine("\n Exercise Summary:\n");
                            foreach (Activity activity in activities)
                            {
                                activity.GetSummary();
                            }
                        }
                        break;

                    case 5:
                        Console.WriteLine("\n Exiting program. Thank you for using the Exercise Tracking Program!");
                        break;

                    default:
                        Console.WriteLine("\n⚠ Invalid option. Please enter a number between 1 and 5.\n");
                        break;
                }
            }
            else
            {
                Console.WriteLine("\n⚠ Invalid input. Please enter a valid number.\n");
            }
        } while (response != 5);
    }
}
