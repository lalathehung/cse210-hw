// EternalGoal.cs
using System;
namespace EternalQuest
{
    public class EternalGoal : Goal
    {
        public EternalGoal(string name, string description, int points) 
            : base(name, description, points) { }

        public override void RecordEvent()
        {
            Console.WriteLine($"📖 Progress recorded for '{ShortName}'!");
        }

        public override bool IsComplete() => false;

        public override string GetStringRepresentation()
        {
            return $"EternalGoal: {ShortName} | {Description} | {Points}";
        }
    }
}
