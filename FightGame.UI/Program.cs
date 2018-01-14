using System;
using System.Collections.Generic;

namespace FightGame.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Warrior> players = new List<Warrior>();
            players.Add(new Warrior("Maximus", 100, 10, 10));
            players.Add(new Warrior("Greedy", 100, 10, 10));
            players.Add(new Warrior("Zero", 100, 10, 10));
            players.Add(new Warrior("Alice", 100, 10, 10));
            players.Add(new Warrior("Cody", 100, 10, 10));
            Battle battle = new Battle(players) ;
            Console.ReadLine();
        }
    }
}
