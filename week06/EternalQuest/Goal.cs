using System;

namespace EternalQuest
{
    public abstract class Goal
    {
        public string ShortName { get; set; }
        public string Description { get; set; }
        public int Points { get; set; }

        public Goal(string name, string description, int points)
        {
            ShortName = name;
            Description = description;
            Points = points;
        }

        public abstract void RecordEvent();
        public abstract int ShowPoints();
        public abstract bool IsComplete();
        public abstract void SetComplete();
        public abstract string GetStringRepresentation();
    }
}
