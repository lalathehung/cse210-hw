// Program.cs
using System;
using System.Collections.Generic;
using EternalQuest;

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager(new List<Goal>(), 0);
        goalManager.Start();
    }
}
