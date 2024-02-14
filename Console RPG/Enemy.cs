using System;
using System.Collections.Generic;

namespace Console_RPG
{
    class Enemy : Entity
    {
        public int coinsDropped;

        //calling the base consructor, then doing the Enemy-Specific stuff
        public Enemy(string name, int hp, int mana, int def, Stats stats, int coinsDropped) : base(name, hp, mana, def, stats)
        {
            this.coinsDropped = coinsDropped;
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
    }
}
