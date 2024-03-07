using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Console_RPG
{
    class Location
    {
        public static bool northDone = false;
        public static bool eastDone = false;
        public static bool southDone = false;
        public static bool westDone = false;

        public static Location startArea = new Location("Middle Area", "(A grimy area with dried blood scattered across the stony floor, 4 doors sit on each of the walls with the names " +
            "of the 4 cardinal directions) \n", new Shop("\"Please give up!\"", new List<Item>() { Item.potion1, Item.potion2, Item.potion3 }));

        public static Location northWing = new Location("North Wing", "(there's shattered glass and oil across the entire floor, a console with a keycard sits at the end of the room. " + 
            "A timer rests on the left wall, you have 2 minutes to figure out what to do, and execute your plan) \n");

        public static Location eastWing = new Location("East Wing", "(A maze of twists and turns lies ahead of you, inside a scorching hot room that's just hot enough to singe your " +
            "skin. You have limited time before you are to die of the heat, enough wrong turns could mean death)\n");

        public static Location southWing = new Location("South Wing", "(You see a a table set out with a deck of cards, behind the table sits a man shivering with fear. He tells you " +
            "that the winner of the game of Blackjack gets to live, and the loser will have their head explode)\n");

        public static Location westWing = new Location("West Wing", "(You see someone chained to a wall by their ankle, holding a shard of glass in a bloody hand, they could be of " +
            "use if you save them)\n", new Battle(new List<Enemy>() { Enemy.kaleb, Enemy.will, Enemy.jackson, Enemy.damon }));


        public string name;
        public string description;
        public Feature feature;

        public Location north, east, south, west;

        public Location(string name, string description, Feature feature = null)
        {
            this.name = name;
            this.description = description;
            this.feature = feature;
        }

        public void SetNearbyLocations(Location north = null, Location east = null, Location south = null, Location west = null)
        {

            if (!(north is null))
            {
                this.north = north;
                north.south = this;
            }

            if (!(east is null))
            {
                this.east = east;
                east.west = this;
            }

            if (!(south is null))
            {
                this.south = south;
                south.north = this;
            }

            if (!(west is null))
            {
                this.west = west;
                west.east = this;
            }
        }
        public void Resolve(List<Player> players)
        {
            Console.WriteLine("\nYou find yourself in a room, " + this.name);
            Console.WriteLine(this.description);

            //Null checking if there's a battle to resolve
            feature?.Resolve(players);

            Console.WriteLine("Which direction would you like to go?");

            if (!(this.north is null))
                Console.WriteLine(this.north.name + ": (north)");

            if (!(this.east is null))
                Console.WriteLine(this.east.name + ": (east)");

            if (!(this.south is null))
                Console.WriteLine(this.south.name + ": (south)");

            if (!(this.west is null))
                Console.WriteLine(this.west.name + ": (west)");


            string direction = Console.ReadLine().ToLower();
            Location nextLocation = null;

            //moving to north wing
            if (direction.Contains("no"))
            {
                nextLocation = this.north;

                gibber:
                Console.WriteLine("What do you want to do?\n");
                Console.WriteLine("1.) Walk across carefully trying not to get cut\n2.) Brush away the broken glass with your feet, clearing a path\n3.) Run across the glass disregarding the pain and bleeding");
                int phteven = Convert.ToInt32(Console.ReadLine());

                if (phteven == 1)
                {
                    //death
                    Console.WriteLine("You waste too much time avoiding injury and a trap activates. Fire busts from the walls lighting the oil on fire, killing you");
                }
                if (phteven == 2)
                {
                    //choice
                    goober:
                    Console.WriteLine("You're making decent progress, if not for the timer. There's enough time to get to the console and back if you run, but the pain will be" +
                        "unbearable. ");
                    Console.WriteLine("Run (1) | Keep brushing away the glass, but faster... (2)");
                    int blob = Convert.ToInt32(Console.ReadLine());

                    if (blob == 1)
                    {
                        //death
                        Console.WriteLine("While running to the console you slip and face plant into the glass shards");
                    }

                    else if (blob == 2)
                    {
                        //live
                        Console.WriteLine("you barely manage to make it to the console, and since you had a path laid out you managed to make it through with minor injuries");
                    }

                    else
                    {
                        Console.WriteLine("Type a valid option");
                        goto goober;
                    }
                }
                if (phteven == 3)
                {
                    //live, but take damage
                    Console.WriteLine("3");
                }
                else
                {
                    Console.WriteLine("Type a valid option");
                    goto gibber; 
                }
            }

            //moving to east wing
            else if (direction.Contains("ea"))
            {
                nextLocation = this.east;

            }

            //moving to south wing
            else if (direction.Contains("so"))
            {
                nextLocation = this.south;

            }

            //moving to west wing
            else if (direction.Contains("we"))
            {
                nextLocation = this.west;

            }

            else
            {
                Console.WriteLine("please enter a valid direction");
                Location.startArea.Resolve(new List<Player>() { Player.player1 });
            }        

            nextLocation.Resolve(players);
        }
    }
}
