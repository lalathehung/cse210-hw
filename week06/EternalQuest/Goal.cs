using System;
namespace EternalQuest
{
    public abstract class Goal
    {
        public string ShortName { get; }
        public string Description { get; }
        public int Points { get; }

        protected Goal(string name, string description, int points)
        {
            ShortName = name;
            Description = description;
            Points = points;
        }

        public abstract void RecordEvent();
        public abstract bool IsComplete();
        public abstract string GetStringRepresentation();
    }
}
