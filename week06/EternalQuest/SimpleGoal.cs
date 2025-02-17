using System;

namespace EternalQuest
{
    public class SimpleGoal : Goal
    {
        private bool _isComplete;

        public SimpleGoal(string name, string description, int points) : base(name, description, points)
        {
            _isComplete = false;
        }

        public SimpleGoal(string name, string description, int points, bool isComplete) : base(name, description, points)
        {
            _isComplete = isComplete;
        }

        public override void RecordEvent()
        {
            if (!_isComplete)
            {
                _isComplete = true;
                Console.WriteLine($"Goal '{ShortName}' completed! You earned {Points} points.");
            }
            else
            {
                Console.WriteLine($"Goal '{ShortName}' is already completed.");
            }
        }

        public override int ShowPoints()
        {
            return Points;
        }

        public override bool IsComplete()
        {
            return _isComplete;
        }

        public override void SetComplete()
        {
            _isComplete = true;
        }

        public override string GetStringRepresentation()
        {
            return $"Simple Goal:{ShortName.Trim()}|{Description.Trim()}|{Points}|{_isComplete}";
        }
    }
}



