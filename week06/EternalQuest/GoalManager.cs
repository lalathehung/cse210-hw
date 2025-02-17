// GoalManager.cs
using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    public class GoalManager
    {
        private List<Goal> _goals;
        private int _score;
        private int _level;
        private List<string> _badges;

        public GoalManager(List<Goal> goals, int score)
        {
            _goals = goals;
            _score = score;
            _level = 1;
            _badges = new List<string>();
        }

        public void Start()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine($"\nYou have {_score} points. Level: {_level}");
                Console.WriteLine("\nMenu Options:");
                Console.WriteLine("1. Create New Goal");
                Console.WriteLine("2. List Goals");
                Console.WriteLine("3. Save Goals");
                Console.WriteLine("4. Load Goals");
                Console.WriteLine("5. Record Event");
                Console.WriteLine("6. Quit");
                Console.Write("Select a choice: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": CreateGoal(); break;
                    case "2": ListGoals(); break;
                    case "3": SaveGoals(); break;
                    case "4": LoadGoals(); break;
                    case "5": RecordEvent(); break;
                    case "6": running = false; Console.WriteLine("Goodbye!"); break;
                    default: Console.WriteLine("Invalid choice. Try again."); break;
                }
            }
        }

        public void CreateGoal()
        {
            Console.WriteLine("\nGoal Types: 1. Simple 2. Eternal 3. Checklist");
            Console.Write("Choose type: ");
            string type = Console.ReadLine();
            
            Console.Write("Goal name: ");
            string name = Console.ReadLine();
            Console.Write("Description: ");
            string description = Console.ReadLine();
            Console.Write("Points: ");
            int points = int.Parse(Console.ReadLine());

            switch (type)
            {
                case "1": _goals.Add(new SimpleGoal(name, description, points)); break;
                case "2": _goals.Add(new EternalGoal(name, description, points)); break;
                case "3":
                    Console.Write("Target Count: ");
                    int target = int.Parse(Console.ReadLine());
                    Console.Write("Bonus Points: ");
                    int bonus = int.Parse(Console.ReadLine());
                    _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                    break;
            }
        }

        public void ListGoals()
        {
            int index = 1;
            foreach (var goal in _goals)
            {
                Console.WriteLine($"{index}. {goal.GetStringRepresentation()}");
                index++;
            }
        }

        public void RecordEvent()
        {
            ListGoals();
            Console.Write("Enter goal number: ");
            int choice = int.Parse(Console.ReadLine()) - 1;
            if (choice >= 0 && choice < _goals.Count)
            {
                _goals[choice].RecordEvent();
                _score += _goals[choice].Points;
                CheckLevelUp();
            }
        }

        private void CheckLevelUp()
        {
            if (_score >= _level * 1000)
            {
                _level++;
                Console.WriteLine($"🎉 Level Up! You are now Level {_level}!");
            }
        }

        // 📝 Save Goals to File
        public void SaveGoals()
        {
            Console.Write("Enter filename to save (include .txt): ");
            string filename = Console.ReadLine();

            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteLine(_score);
                foreach (Goal goal in _goals)
                {
                    writer.WriteLine(goal.GetStringRepresentation());
                }
            }

            Console.WriteLine($"✅ Goals saved successfully to {filename}.");
        }

        // 📝 Load Goals from File
        public void LoadGoals()
        {
            Console.Write("Enter filename to load (include .txt): ");
            string filename = Console.ReadLine();

            if (!File.Exists(filename))
            {
                Console.WriteLine("❌ Error: File not found.");
                return;
            }

            _goals.Clear();
            using (StreamReader reader = new StreamReader(filename))
            {
                if (!int.TryParse(reader.ReadLine(), out _score))
                {
                    Console.WriteLine("❌ Error: Invalid score format in file.");
                    return;
                }

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length < 4)
                    {
                        Console.WriteLine("❌ Error: Invalid goal format.");
                        continue;
                    }

                    string type = parts[0].Trim();
                    string name = parts[1].Trim();
                    string description = parts[2].Trim();

                    if (!int.TryParse(parts[3].Trim(), out int points))
                    {
                        Console.WriteLine($"❌ Error: Invalid points format in goal: {line}");
                        continue;
                    }

                    if (type.StartsWith("SimpleGoal"))
                    {
                        bool isComplete = parts.Length > 4 && bool.TryParse(parts[4].Trim(), out bool completed) && completed;
                        _goals.Add(new SimpleGoal(name, description, points));
                    }
                    else if (type.StartsWith("EternalGoal"))
                    {
                        _goals.Add(new EternalGoal(name, description, points));
                    }
                    else if (type.StartsWith("ChecklistGoal"))
                    {
                        if (parts.Length < 7 ||
                            !int.TryParse(parts[4].Trim(), out int amountCompleted) ||
                            !int.TryParse(parts[5].Trim(), out int target) ||
                            !int.TryParse(parts[6].Trim(), out int bonus))
                        {
                            Console.WriteLine($"❌ Error: Invalid checklist goal format: {line}");
                            continue;
                        }

                        _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                    }
                }
            }

            Console.WriteLine($"✅ Goals loaded successfully from {filename}.");
        }
    }
}
