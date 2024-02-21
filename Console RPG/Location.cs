using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    class Location
    {
        public static Location startArea = new Location("Middle Area", "(Where you woke up)");
        public static Location northWing = new Location("North Wing", "(there's shattered glass and oil across the entire floor, a console with a keycard sits at the end of the room. " + 
            "A timer rests on the left wall, you have 2 minutes to figure out what to do, and execute your plan)");
        public static Location eastWing = new Location("East Wing", "(Brainrot central)");
        public static Location southWing = new Location("South Wing", "(More of a house for his cat)");
        public static Location westWing = new Location("West Wing", "(pretty normal house)", new Battle(new List<Enemy>() { Enemy.kaleb, Enemy.will, Enemy.jackson, Enemy.damon }));
        public static Location ladderOut = new Location("Ladder Up", "(A ladder that seemily leads to your escape)");

        public string name;
        public string description;
        public Battle battle;

        public Location north, east, south, west, up, down;

        public Location(string name, string description, Battle battle = null)
        {
            this.name = name;
            this.description = description;
            this.battle = battle;
        }

        public void SetNearbyLocations(Location north = null, Location east = null, Location south = null, Location west = null, Location up = null, Location down = null)
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

            if (!(up is null))
            {
                this.up = up;
                up.down = this;
            }

            if (!(up is null))
            {
                this.down = down;
                down.up = this;
            }
        }
        public void Resolve(List<Player> players)
        {
            Console.WriteLine("You find yourself in a room, " + this.name);
            Console.WriteLine(this.description);

            //Null checking if there's a battle to resolve
            battle?.Resolve(players);

            if (!(this.north is null))
                Console.WriteLine("NORTH " + this.north.name);

            if (!(this.east is null))
                Console.WriteLine("EAST " + this.east.name);

            if (!(this.south is null))
                Console.WriteLine("SOUTH " + this.south.name);

            if (!(this.west is null))
                Console.WriteLine("WEST " + this.west.name);
            
            if (!(this.up is null))
                Console.WriteLine("UP " + this.up.name);


            string direction = Console.ReadLine();
            Location nextLocation = null;           

            if (direction == "north")
                nextLocation = this.north;
            if (direction == "east")
                nextLocation = this.east;
            if (direction == "south")
                nextLocation = this.south;
            if (direction == "west")
                nextLocation = this.west;
            if (direction == "up")
                nextLocation = this.up;

            nextLocation.Resolve(players);
        }
    }
}
