using System;

namespace Console_RPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Enemy derek = new Enemy("derek", 100, 100, 0, new Stats(attack: 1000, defense: 1000, magicAtk: 1000, magicDef: 1000), 100_000);
            Player player1 = new Player("You", 100, 0, 100, new Stats(attack: 100, defense: 100, magicAtk: 100, magicDef: 100), 0);
            Player player2 = new Player("Player2", 100, 0, 100, new Stats(attack: 100, defense: 100, magicAtk: 100, magicDef: 100), 0);
            Enemy enemy1 = new Enemy("Slime", 100, 100, 0, new Stats(attack: 10, defense: 80, magicAtk: 10, magicDef: 150), 10);
            Enemy enemy2 = new Enemy("Goblin(deez nutz)",100, 100, 0, new Stats(attack: 20, defense: 50, magicAtk: 30, magicDef: 10), 25);

            HealthPotionItem potion1 = new HealthPotionItem("Potion I", "It'll quench ya", 10, 5, 20);
            HealthPotionItem potion2 = new HealthPotionItem("Potion II", "Even quenchier???", 25, 20, 40);
            HealthPotionItem potion3 = new HealthPotionItem("Potion III", "WOW, now that's quenchy", 75, 50, 80);

            BoomStickItem boomStick = new BoomStickItem("Stick goes boom", "Have you ever seen someone and immediately wanted to BLOW THEM THE F*** UP? Well now you can!", 200, 1, 100, 3);


            player1.UseItem(potion1, enemy1);
        }
    }
}
