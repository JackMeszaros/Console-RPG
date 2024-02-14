using System;
using System.Collections.Generic;

namespace Console_RPG
{
    //Inheritance
    class Player : Entity
    {
        public int coinsOwned;

        //calling the base consructor, then doing the Enemy-Specific stuff
        public Player(string name, int hp, int mana, int def, Stats stats, int coinsOwned) : base(name, hp, mana, def, stats)
        {
            this.coinsOwned = coinsOwned;
        }

        public override Entity Choosetarget(List<Entity> choices)
        {
            //figure out how to ask the player who they want to attack
            throw new NotImplementedException();
        }
        public override void Attack(Entity target)
        {
            //figure out how to calculate the damage and subtract from target's hp
            Console.WriteLine(this.name + " attacked " + target.name + "!");
        }

        public void UseItem(Item item, Entity target)
        {
            item.use(this, target);
        }
    }
}
