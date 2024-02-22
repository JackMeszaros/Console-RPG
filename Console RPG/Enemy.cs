using System;
using System.Linq;
using System.Collections.Generic;

namespace Console_RPG
{
    class Enemy : Entity
    {
        public static Enemy kaleb = new Enemy("Kaleb", 30, -20, 3, new Stats());
        public static Enemy will = new Enemy("will", -50, 30, 3, new Stats());
        public static Enemy jackson = new Enemy("Jackson", 2, 3, 3, new Stats());
        public static Enemy damon = new Enemy("Damon", -4, -0, 3, new Stats());

        public static Enemy derek = new Enemy("derek", 100, 100, 0, new Stats(attack: 1000, defense: 1000, magicAtk: 1000, magicDef: 1000));
        public static Enemy enemy1 = new Enemy("Slime", 100, 100, 0, new Stats(attack: 10, defense: 80, magicAtk: 10, magicDef: 150));
        public static Enemy enemy2 = new Enemy("Goblin(deez nutz)", 100, 100, 0, new Stats(attack: 20, defense: 50, magicAtk: 30, magicDef: 10));

        //calling the base consructor, then doing the Enemy-Specific stuff
        public Enemy(string name, int hp, int mana, int def, Stats stats) : base(name, hp, mana, def, stats)
        {
        }
       
        public override Entity Choosetarget(List<Entity> choices)
        {
            //using a random object lets us specify a seed and make consistent runs
            Random random = new Random();
            return choices[random.Next(0, choices.Count)];
        }

        public override void Attack(Entity target)
        {
            //figure out how to calculate the damage and subtract from target's hp
            Console.WriteLine(this.name + " attacked " + target.name + "!");
        }

        public override void DoTurn(List<Player> players, List<Enemy> enemies)
        {
            Entity target = Choosetarget(players.Cast<Entity>().ToList());
            Attack(target);
        }
    }
}
