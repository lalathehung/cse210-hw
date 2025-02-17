using System;
using System.Collections.Generic; // Required for List<Goal>
using EternalQuest;

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager(new List<Goal>(), 0);
        goalManager.Start();
    }
}
