using System;
using System.Linq;
using System.Collections.Generic;

namespace Console_RPG
{
    //Inheritance
    class Player : Entity
    {
        public static List<Item> Inventory = new List<Item>() 
        { 
            HealthPotionItem.potion1, 
            HealthPotionItem.potion2, 
            HealthPotionItem.potion3 
        };
        public static int CoinCount = 0;

        //public static Player ruth = new Player("Ruth", 30, 20, 3, new Stats());
        //public static Player jaden = new Player("jaden", -200, -10, 3, new Stats());
        //public static Player lapis = new Player("lapis", 30, 40, 3, new Stats());
        //public static Player emile = new Player("emile", 10000, 20000, 3, new Stats());

        public static Player player1 = new Player("Name", 100, 0, 100, new Stats(attack: 100, defense: 100, magicAtk: 100, magicDef: 100));
        //public static Player player2 = new Player("Player2", 100, 0, 100, new Stats(attack: 100, defense: 100, magicAtk: 100, magicDef: 100));

        public Armor headgear, cheastpiece, footwear;
        public Weapon weapon;

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

        public Item ChooseItem(List<Item> choices)
        {
            Console.WriteLine("<Choose an item to use>");

            for (int i = 0; i < choices.Count; i++)
            {
                Console.WriteLine($"{i + 1} {choices[i].name}");
            }

            int index = Convert.ToInt32(Console.ReadLine());
            return choices[index - 1];
        }
        public override void Attack(Entity target)
        {
            //figure out how to calculate the damage and subtract from target's hp
            Console.WriteLine(this.name + " attacked " + target.name + "!");
        }
        public override void DoTurn(List<Player> players, List<Enemy> enemies)
        {

            Console.WriteLine("What do you want to do?");
            Console.WriteLine("ATTACK | ITEM");
            string choice = Console.ReadLine(); 

            if (choice == "attack")
            {
                Entity target = Choosetarget(enemies.Cast<Entity>().ToList());
                Attack(target);
            }
            else if (choice == "item")
            {
                Item item = ChooseItem(Inventory);
                Entity target = Choosetarget(enemies.Cast<Entity>().ToList());

                item.use(this, target);
                Inventory.Remove(item);
            }
            else
            {
                Console.WriteLine("Enter a valid option");
            }
        }

        public void UseItem(Item item, Entity target)
        {

            item.use(this, target);

        }
    }
}
