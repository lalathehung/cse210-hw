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

        public void CreateGoal(Goal goal)
        {
            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine();

            Console.Write("What is a short description of your goal? ");
            string description = Console.ReadLine();

            Console.Write("How many points would you like associated with this goal? ");
            if (!int.TryParse(Console.ReadLine(), out int points))
            {
                Console.WriteLine("Invalid input. Setting points to 0.");
                points = 0;
            }

            goal.ShortName = name;
            goal.Description = description;
            goal.Points = points;
            _goals.Add(goal);
        }

        public void Start()
        {
            bool running = true;
            GoalManager goalManager = GetGoalManager();
            while (running)
            {
                Console.WriteLine($"\n🎯 You are Level {_level} with {_xp}/{_xpToNextLevel} XP.");
                Console.WriteLine($"🏆 You have {_score} points.");

                Console.WriteLine("\nMenu Options:");
                Console.WriteLine("  1. Create New Goal");
                Console.WriteLine("  2. List Goals");
                Console.WriteLine("  3. Save Goals");
                Console.WriteLine("  4. Load Goals");
                Console.WriteLine("  5. Record Event");
                Console.WriteLine("  6. Quit");

                Console.Write("Select a choice from the menu: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Clear();
                    Console.WriteLine("\nThe types of goals are:");
                    Console.WriteLine("  1. Simple Goal");
                    Console.WriteLine("  2. Eternal Goal");
                    Console.WriteLine("  3. Checklist Goal");
                    Console.Write("Which type of goal would you like to create? ");
                    string goalType = Console.ReadLine();

                    if (goalType == "1")
                    {
                        SimpleGoal simpleGoal = new SimpleGoal("", "", 0);
                        goalManager.CreateGoal(simpleGoal);
                        Console.WriteLine($"New goal: {simpleGoal.ShortName} has been created!");
                    }
                    else if (goalType == "2")
                    {
                        EternalGoal eternalGoal = new EternalGoal("", "", 0);
                        goalManager.CreateGoal(eternalGoal);
                        Console.WriteLine($"New goal: {eternalGoal.ShortName} has been created!");
                    }
                    else if (goalType == "3")
                    {
                        ChecklistGoal checklistGoal = new ChecklistGoal("", "", 0, 0, 0);
                        goalManager.CreateGoal(checklistGoal);

                        Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                        if (!int.TryParse(Console.ReadLine(), out int targetAnswer))
                        {
                            Console.WriteLine("Invalid input. Setting target to 1.");
                            targetAnswer = 1;
                        }
                        checklistGoal.Target = targetAnswer;

                        Console.Write("What is the bonus for accomplishing it that many times? ");
                        if (!int.TryParse(Console.ReadLine(), out int bonusAnswer))
                        {
                            Console.WriteLine("Invalid input. Setting bonus to 0.");
                            bonusAnswer = 0;
                        }
                        checklistGoal.Bonus = bonusAnswer;

                        Console.WriteLine($"New goal: {checklistGoal.ShortName} has been created!");
                    }
                }
                else if (choice == "2")
                {
                    Console.WriteLine("\nYour goals are: ");
                    goalManager.ListGoalNames();
                }
                else if (choice == "3")
                {
                    goalManager.SaveGoals();
                }
                else if (choice == "4")
                {
                    goalManager.LoadGoals();
                }
                else if (choice == "5")
                {
                    goalManager.ListGoalNames();
                    goalManager.RecordEvent();
                }
                else if (choice == "6")
                {
                    running = false;
                    Console.WriteLine("\nGoodbye!\n");
                }
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
                    int amount = checklistGoal.Amount;
                    int target = checklistGoal.Target;
                    Console.WriteLine($"  {count}. [{(goal.IsComplete() ? "x" : " ")}] {name} ({description}) -- Completed {amount}/{target}");
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
            if (int.TryParse(Console.ReadLine(), out int goalIndex) && goalIndex > 0 && goalIndex <= _goals.Count)
            {
                Goal thisGoal = _goals[goalIndex - 1];
                thisGoal.RecordEvent();

                int pointsEarned = thisGoal.ShowPoints();
                _score += pointsEarned;
                _xp += pointsEarned;

                Console.WriteLine($"You earned {pointsEarned} XP! 🎉");
                CheckLevelUp();
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid goal number.");
            }
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

            if (string.IsNullOrWhiteSpace(fileName))
            {
                Console.WriteLine("Invalid filename. Save operation aborted.");
                return;
            }

            try
            {
                List<string> goalRepList = new List<string>();
                goalRepList.Add($"{_level}|{_xp}|{_xpToNextLevel}|{_score}");

                foreach (Goal goal in _goals)
                {
                    string goalString = goal.GetStringRepresentation();
                    goalRepList.Add(goalString);
                }

                File.WriteAllLines(fileName, goalRepList);
                Console.WriteLine($"Goals saved successfully to {fileName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving goals: {ex.Message}");
            }
        }

        public void LoadGoals()
        {
            Console.Write("What file would you like to load (include extension)? ");
            string fileName = Console.ReadLine();
            if (!File.Exists(fileName))
            {
                Console.WriteLine("File not found.");
                return;
            }

            string[] firstLine = File.ReadLines(fileName).First().Split("|");
            _level = int.Parse(firstLine[0]);
            _xp = int.Parse(firstLine[1]);
            _xpToNextLevel = int.Parse(firstLine[2]);
            _score = int.Parse(firstLine[3]);

            _goals.Clear();
            foreach (string line in File.ReadLines(fileName).Skip(1))
            {
                Console.WriteLine($"Loaded: {line}");
            }
        }

        public int GetScore()
        {
            return _score;
        }

        public GoalManager GetGoalManager()
        {
            return this;
        }
    }
}
