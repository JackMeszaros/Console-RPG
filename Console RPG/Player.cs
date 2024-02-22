using System;
using System.Linq;
using System.Collections.Generic;

namespace Console_RPG
{
    //Inheritance
    class Player : Entity
    {
        //public static Player ruth = new Player("Ruth", 30, 20, 3, new Stats());
        //public static Player jaden = new Player("jaden", -200, -10, 3, new Stats());
        //public static Player lapis = new Player("lapis", 30, 40, 3, new Stats());
        //public static Player emile = new Player("emile", 10000, 20000, 3, new Stats());

        public static Player player1 = new Player("Name", 100, 0, 100, new Stats(attack: 100, defense: 100, magicAtk: 100, magicDef: 100));
        //public static Player player2 = new Player("Player2", 100, 0, 100, new Stats(attack: 100, defense: 100, magicAtk: 100, magicDef: 100));

        //calling the base consructor, then doing the Enemy-Specific stuff
        public Player(string name, int hp, int mana, int def, Stats stats) : base(name, hp, mana, def, stats)
        {
        }

        public override Entity Choosetarget(List<Entity> choices)
        {
            Console.WriteLine("<Choose a target to attack>");

            for (int i = 0; i < choices.Count; i++)
            {                
                Console.WriteLine($"{i +1} {choices[i].name}");
            }

            int index = Convert.ToInt32(Console.ReadLine());
            return choices[index -1];
        }
        public override void Attack(Entity target)
        {
            //figure out how to calculate the damage and subtract from target's hp
            Console.WriteLine(this.name + " attacked " + target.name + "!");
        }
        public override void DoTurn(List<Player> players, List<Enemy> enemies)
        {
            Entity target = Choosetarget(enemies.Cast<Entity>().ToList());
            Attack(target);
        }

        public void UseItem(Item item, Entity target)
        {
            item.use(this, target);
        }
    }
}
