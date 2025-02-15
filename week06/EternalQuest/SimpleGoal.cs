// SimpleGoal.cs
using System;
namespace EternalQuest
{
    public class SimpleGoal : Goal
    {
        private bool _isComplete;

        public SimpleGoal(string name, string description, int points) 
            : base(name, description, points)
        {
            _isComplete = false;
        }

        public override void RecordEvent()
        {
            _isComplete = true;
            Console.WriteLine($"🎯 Goal '{ShortName}' completed! You earned {Points} points.");
        }

        public override bool IsComplete() => _isComplete;

        public override string GetStringRepresentation()
        {
            return $"SimpleGoal: {ShortName} | {Description} | {Points} | {_isComplete}";
        }
    }
}
