using System;
using System.Collections.Generic;

namespace Console_RPG
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("What is your name?");

            string PlayerName = Console.ReadLine();
            Player.player1.name = PlayerName;

            Location.startArea.SetNearbyLocations(north: Location.northWing,  south: Location.southWing, east: Location.eastWing, west: Location.westWing);
            Location.startArea.Resolve(new List<Player>() { Player.player1 });

            // This would add a health potion 1 to the player's inventory
            Player.Inventory.Add(Item.potion1);

            // This would print the name of the first item in the list 
            Console.WriteLine(Player.Inventory[0].name);

            // This!
            Player.Inventory.Remove(Item.potion1);

            // remove first item
            Player.Inventory.RemoveAt(0);

            // remove everything 
            Player.Inventory.Clear();

            // yuh

        }
    }
}
