using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    class Battle
    {
        public List<Enemy> enemies;
        public bool isResolved;

        public Battle(List<Enemy> enemies)
        {
            this.enemies = enemies;
            this.isResolved = false;
        }

        public void Resolve(List<Player> players)
        {
            //loop the turn system
            while (true)
            {
                //loop through all players
                foreach (var item in players)
                {
                    Console.WriteLine($"It is {item.name}'s turn");
                    item.DoTurn(players, enemies);
                }

                //Loop through enemies
                foreach (var item in enemies)
                {
                    Console.WriteLine($"It is {item.name}'s turn");
                    item.DoTurn(players, enemies);
                }

                //if player dies
                if (players.TrueForAll(player => player.currentHP <= 0))
                {
                    Console.WriteLine("You died");
                    break;
                }
                
                //if enemy dies
                if (players.TrueForAll(enemy => enemy.currentHP <= 0))
                {
                    Console.WriteLine("You killed someone");
                    break;
                }
            }

            Console.WriteLine("The fight has ended");
        }
    }
}
