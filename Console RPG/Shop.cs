using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    class Shop : Feature
    {
        public string shopName;
        public List<Item> items;

        public Shop(string shopName, List<Item> items) : base(false)
        {
            this.shopName = shopName;
            this.items = items;
        }

        public override void Resolve(List<Player> players)
        {
            if ((Location.northDone && Location.eastDone) || (Location.northDone && Location.southDone) || (Location.northDone && Location.westDone) 
                || (Location.eastDone && Location.southDone) || (Location.eastDone && Location.westDone) || (Location.southDone && Location.westDone))
            {
                while (true)
                {
                    Console.WriteLine($"Welcome to {shopName}! Buy something or else!");

                    Console.WriteLine("What would you like to do\n");
                    Console.WriteLine("BUY | SELL | LEAVE | ATTACK");
                    string userChoice = Console.ReadLine().ToLower();

                    if (userChoice == "buy")
                    {
                        Console.WriteLine("<Choose an item to buy>");
                        Item item = ChooseItem(this.items);


                        if (Player.CoinCount >= item.shopPrice)
                        {
                            Player.CoinCount -= item.shopPrice;
                            Player.Inventory.Add(item);

                            Console.WriteLine($"You've received {item.name}");
                        }
                        else
                        {
                            Console.WriteLine("You're too broke for that ");
                        }
                    }

                    else if (userChoice == "sell")
                    {
                        Console.WriteLine("<Choose an item to sell>");
                        Item item = ChooseItem(Player.Inventory);
                        Player.CoinCount += item.sellPrice;
                        Player.Inventory.Remove(item);
                    }

                    else if (userChoice == "leave")
                    {
                        break;
                    }

                    else if (userChoice == "attack")
                    {

                    }

                    else
                    {
                        Console.WriteLine("Enter a valid option");

                    }
                }

                Console.WriteLine("Good riddance");
            }
        }

        public Item ChooseItem(List<Item> choices)
        {


            for (int i = 0; i < choices.Count; i++)
            {
                Console.WriteLine($"{i + 1} {choices[i].name} ({choices[i].shopPrice})");
            }

            // Let the user pick a choice
            int index = Convert.ToInt32(Console.ReadLine());
            return choices[index - 1];
        }
    }
}
