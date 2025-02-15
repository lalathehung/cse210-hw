// ChecklistGoal.cs
using System;
namespace EternalQuest
{
    public class ChecklistGoal : Goal
    {
        private int _amountCompleted;
        private int _target;
        private int _bonus;

        public ChecklistGoal(string name, string description, int points, int target, int bonus) 
            : base(name, description, points)
        {
            _amountCompleted = 0;
            _target = target;
            _bonus = bonus;
        }

        public int Amount => _amountCompleted;
        public int Target => _target;
        public int Bonus => _bonus;

        public override void RecordEvent()
        {
            _amountCompleted++;
            Console.WriteLine($"✅ {ShortName}: Completed {_amountCompleted}/{_target} times!");

            if (_amountCompleted >= _target)
            {
                Console.WriteLine($"🎉 Bonus unlocked! You earned {_bonus} extra points!");
            }
        }

        public override bool IsComplete() => _amountCompleted >= _target;

        public override string GetStringRepresentation()
        {
            return $"ChecklistGoal: {ShortName} | {Description} | {Points} | {_amountCompleted}/{_target} | {_bonus}";
        }
    }
}
