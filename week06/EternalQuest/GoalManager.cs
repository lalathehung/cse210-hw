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
        private int _xp;
        private int _xpToNextLevel;

        public GoalManager(List<Goal> goals, int score)
        {
            _goals = goals ?? new List<Goal>();
            _score = score;
            _level = 1; // Start at Level 1
            _xp = 0; // Start with 0 XP
            _xpToNextLevel = 100; // XP required for Level 2
        }

        public void Start()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine($"\n🎯 You are Level {_level} with {_xp}/{_xpToNextLevel} XP.");
                Console.WriteLine($"🏆 You have {_score} points.");
                Console.WriteLine($"\nMenu Options:");

                Console.WriteLine($"  1. Create New Goal");
                Console.WriteLine($"  2. List Goals");
                Console.WriteLine($"  3. Save Goals");
                Console.WriteLine($"  4. Load Goals");
                Console.WriteLine($"  5. Record Event");
                Console.WriteLine($"  6. Quit");

                Console.Write("Select a choice from the menu: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    CreateGoal();
                }
                else if (choice == "2")
                {
                    Console.WriteLine("\nYour goals are: ");
                    ListGoalNames();
                }
                else if (choice == "3")
                {
                    SaveGoals();
                }
                else if (choice == "4")
                {
                    LoadGoals();
                }
                else if (choice == "5")
                {
                    ListGoalNames();
                    RecordEvent();
                }
                else if (choice == "6")
                {
                    running = false;
                    Console.WriteLine("\nGoodbye!\n");
                }
            }
        }

        public void CreateGoal()
        {
            Console.Clear();
            Console.WriteLine("\nThe types of goals are:");
            Console.WriteLine($"  1. Simple Goal");
            Console.WriteLine($"  2. Eternal Goal");
            Console.WriteLine($"  3. Checklist Goal");
            Console.Write("Which type of goal would you like to create? ");
            string goalType = Console.ReadLine();

            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine();

            Console.Write("What is a short description of your goal? ");
            string description = Console.ReadLine();

            Console.Write("How many points would you like associated with this goal? ");
            int points = int.Parse(Console.ReadLine());

            if (goalType == "1")
            {
                _goals.Add(new SimpleGoal(name, description, points));
                Console.WriteLine($"New Simple Goal '{name}' has been created!");
            }
            else if (goalType == "2")
            {
                _goals.Add(new EternalGoal(name, description, points));
                Console.WriteLine($"New Eternal Goal '{name}' has been created!");
            }
            else if (goalType == "3")
            {
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());

                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());

                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                Console.WriteLine($"New Checklist Goal '{name}' has been created!");
            }
        }

        public void ListGoalNames()
        {
            int count = 0;
            foreach (Goal goal in _goals)
            {
                count++;
                string name = goal.ShortName;
                string description = goal.Description;

                if (goal is ChecklistGoal checklistGoal)
                {
                    Console.WriteLine($"  {count}. [{(goal.IsComplete() ? "x" : " ")}] {name} ({description}) -- Completed {checklistGoal.Amount}/{checklistGoal.Target}");
                }
                else
                {
                    Console.WriteLine($"  {count}. [{(goal.IsComplete() ? "x" : " ")}] {name} ({description})");
                }
            }
        }

        public void RecordEvent()
        {
            Console.Write("Which goal did you accomplish? ");
            int goalIndex = int.Parse(Console.ReadLine()) - 1;

            if (goalIndex < 0 || goalIndex >= _goals.Count)
            {
                Console.WriteLine("Invalid goal selection.");
                return;
            }

            Goal thisGoal = _goals[goalIndex];

            if (thisGoal is ChecklistGoal checklistGoal)
            {
                checklistGoal.Amount += 1;
                _score += checklistGoal.Points;
                _xp += checklistGoal.Points;

                if (checklistGoal.Amount == checklistGoal.Target)
                {
                    _score += checklistGoal.Bonus;
                    _xp += checklistGoal.Bonus;
                    Console.WriteLine($"🎉 You completed the target for this goal! Bonus {checklistGoal.Bonus} points awarded!");
                }

                Console.WriteLine($"You have completed this {checklistGoal.Amount}/{checklistGoal.Target} times.");
            }
            else
            {
                thisGoal.SetComplete();
                _score += thisGoal.ShowPoints();
                _xp += thisGoal.ShowPoints();
                Console.WriteLine($"Congratulations on completing {thisGoal.ShortName}!");
            }

            CheckLevelUp();
        }

        public void CheckLevelUp()
        {
            while (_xp >= _xpToNextLevel)
            {
                _xp -= _xpToNextLevel;
                _level++;
                _xpToNextLevel += 50;
                Console.WriteLine($"🎉 Congratulations! You leveled up to Level {_level}! 🎯");
            }
        }

        public void SaveGoals()
        {
            Console.Write("What would you like to name your file (include .txt extension)? ");
            string fileName = Console.ReadLine();

            List<string> goalRepList = new List<string> { $"{_level}|{_xp}|{_xpToNextLevel}|{_score}" };

            foreach (Goal goal in _goals)
            {
                goalRepList.Add(goal.GetStringRepresentation());
            }

            File.WriteAllLines(fileName, goalRepList);
            Console.WriteLine($"Saved: {fileName}");
        }

        public void LoadGoals()
        {
            Console.Write("What file would you like to load (include extension)? ");
            string fileName = Console.ReadLine();
            if (!File.Exists(fileName))
            {
                Console.WriteLine("❌ File not found.");
                return;
            }

            string[] fileLines = File.ReadAllLines(fileName);
            if (fileLines.Length == 0)
            {
                Console.WriteLine("❌ The file is empty. Cannot load goals.");
                return;
            }

            string[] firstLine = fileLines[0].Split("|");
            _level = int.Parse(firstLine[0]);
            _xp = int.Parse(firstLine[1]);
            _xpToNextLevel = int.Parse(firstLine[2]);
            _score = int.Parse(firstLine[3]);

            _goals.Clear();

            foreach (string line in fileLines.Skip(1))
            {
                Console.WriteLine($"Loaded: {line}");
            }

            Console.WriteLine($"✅ Successfully loaded goals from {fileName}!");
        }

        public int GetScore()
        {
            return _score;
        }

        public List<Goal> GetGoalsList()
        {
            return _goals;
        }

        public GoalManager GetGoalManager()
        {
            return new GoalManager(new List<Goal>(), 0);
        }
    }
}






