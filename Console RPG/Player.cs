using System;
using System.Collections.Generic;

namespace Console_RPG
{
    //Inheritance
    class Player : Entity
    {
        public static Player ruth = new Player("Ruth", 30, 20, 3, new Stats());
        public static Player jaden = new Player("jaden", -200, -10, 3, new Stats());
        public static Player lapis = new Player("lapis", 30, 40, 3, new Stats());
        public static Player emile = new Player("emile", 10000, 20000, 3, new Stats());

        public static Player player1 = new Player("Name", 100, 0, 100, new Stats(attack: 100, defense: 100, magicAtk: 100, magicDef: 100));
        public static Player player2 = new Player("Player2", 100, 0, 100, new Stats(attack: 100, defense: 100, magicAtk: 100, magicDef: 100));

        //calling the base consructor, then doing the Enemy-Specific stuff
        public Player(string name, int hp, int mana, int def, Stats stats) : base(name, hp, mana, def, stats)
        {
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
