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
        }
    }
}
