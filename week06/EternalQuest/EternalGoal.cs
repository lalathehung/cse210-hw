using System;

namespace EternalQuest
{
    public class EternalGoal : Goal
    {
        private string _goalType;

        public EternalGoal(string name, string description, int points) : base(name, description, points)
        {
            _goalType = "Eternal Goal";
        }

        public string GoalType
        {
            get => _goalType;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    _goalType = value;
            }
        }

        public override void RecordEvent()
        {
            Console.WriteLine($"Progress recorded for '{ShortName}'. Keep going!");
        }

        public override int ShowPoints()
        {
            return Points;
        }

        public override bool IsComplete()
        {
            return false; // Eternal goals are never completed
        }

        public override void SetComplete()
        {
            // Eternal goals never complete, so do nothing.
        }

        public override string GetStringRepresentation()
        {
            return $"{_goalType}: {ShortName} | {Description} | {Points}";
        }
    }
}
