using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    class Location
    {
        public static Location startArea = new Location("Middle Area", "(A grimy area with dried blood scattered across the stony floor, 4 doors sit on each of the walls with the names " +
            "of the 4 cardinal directions) \n");

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
        public Battle battle;

        public Location north, east, south, west;

        public Location(string name, string description, Battle battle = null)
        {
            this.name = name;
            this.description = description;
            this.battle = battle;
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
            battle?.Resolve(players);

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

            if (direction.Contains("no"))
            {
                nextLocation = this.north;

            }
            else if (direction.Contains("ea"))
            {
                nextLocation = this.east;

            }
            else if (direction.Contains("so"))
            {
                nextLocation = this.south;

            }
            else if (direction.Contains("we"))
            {
                nextLocation = this.west;

            }
            else
                Console.WriteLine("please enter a valid direction");

            nextLocation.Resolve(players);
        }
    }
}
