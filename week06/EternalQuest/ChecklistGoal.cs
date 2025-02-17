using System;

namespace EternalQuest
{
    public class ChecklistGoal : Goal
    {
        private string _goalType;
        private bool _isComplete;
        private int _amountCompleted;
        private int _target;
        private int _bonus;

        public ChecklistGoal(string name, string description, int points, int target, int bonus, int amountCompleted = 0, bool isComplete = false) 
            : base(name, description, points)
        {
            _goalType = "Checklist Goal";
            _isComplete = isComplete;
            _amountCompleted = amountCompleted;
            _target = target;
            _bonus = bonus;
        }

        public int Amount
        {
            get => _amountCompleted;
            set
            {
                if (value >= 0)
                    _amountCompleted = value;
            }
        }

        public int Target
        {
            get => _target;
            set
            {
                if (value >= 0)
                    _target = value;
            }
        }

        public int Bonus
        {
            get => _bonus;
            set
            {
                if (value >= 0)
                    _bonus = value;
            }
        }

        public override void RecordEvent()
        {
            Amount++;

            Console.WriteLine($"Progress recorded for '{ShortName}'. Completed {Amount}/{Target} times.");

            if (Amount >= Target)
            {
                _isComplete = true;
                Console.WriteLine($"Congratulations! Goal '{ShortName}' completed! You earned {Bonus} bonus points!");
            }
        }

        public override int ShowPoints()
        {
            return Amount >= Target ? Points + Bonus : Points;
        }

        public override bool IsComplete()
        {
            return Amount >= Target;
        }

        public override void SetComplete()
        {
            _isComplete = true;
        }

        public override string GetStringRepresentation()
        {
            return $"{_goalType}|{ShortName}|{Description}|{Points}|{_isComplete}|{Amount}|{Target}|{Bonus}";
        }
    }
}

