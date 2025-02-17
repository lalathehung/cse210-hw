using System;
using System.Collections.Generic; // Required for List<Goal>
using EternalQuest;
//Creativity: I have added an achievement system, when the user reaches a certain level, the user will receive a certain title.
class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager(new List<Goal>(), 0);
        goalManager.Start();
    }
}
