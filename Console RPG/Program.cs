using System;

namespace Console_RPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Enemy derek = new Enemy("derek", 100, 100, new Stats(attack: 1000, defense: 1000, magicAtk: 1000, magicDef: 1000), 100_000);
            Player player = new Player("Player1", 100, 100, new Stats(attack: 100, defense: 100, magicAtk: 100, magicDef: 100), 0);
            Player player2 = new Player("Player2", 100, 100, new Stats(attack: 100, defense: 100, magicAtk: 100, magicDef: 100), 0);
            Enemy enemy = new Enemy("Slime", 100, 100, new Stats(attack: 10, defense: 80, magicAtk: 10, magicDef: 150), 10);
            Enemy enemy2 = new Enemy("Goblin(deez nutz)", 100, 100, new Stats(attack: 20, defense: 50, magicAtk: 30, magicDef: 10), 25);

            Console.WriteLine(derek.stats.attack);
        }
    }
}
