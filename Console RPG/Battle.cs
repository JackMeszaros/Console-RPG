using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    class Battle : Feature
    {
        public List<Enemy> enemies;

        public Battle(List<Enemy> enemies) : base(false)
        {
            this.enemies = enemies;
        }

        public override void Resolve(List<Player> players)
        {
            //loop the turn system
            while (true)
            {
                //loop through all players
                foreach (var player in players)
                {
                    if (player.currentHP > 0)
                    Console.WriteLine($"It is {player.name}'s turn");
                    player.DoTurn(players, enemies);
                }

                //Loop through enemies
                foreach (var enemy in enemies)
                {
                    if (enemy.currentHP > 0)
                    Console.WriteLine($"It is {enemy.name}'s turn");
                    enemy.DoTurn(players, enemies);
                }

                //if player dies
                if (players.TrueForAll(player => player.currentHP <= 0))
                {
                    Console.WriteLine("You died, your body will be put to use even after death.");
                    break;
                }
                
                //if enemy dies
                if (players.TrueForAll(enemy => enemy.currentHP <= 0))
                {
                    Console.WriteLine("You killed someone.");
                    break;
                }
            }

            Console.WriteLine("The fight has ended");
        }
    }
}
