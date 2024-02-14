using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    abstract class Item
    {
        public string name;
        public string description;
        public int shopPrice;
        public int sellPrice;

        public Item(string name, string description, int shopPrice, int sellPrice)
        {
            this.name = name;
            this.description = description;
            this.shopPrice = shopPrice;
            this.sellPrice = sellPrice;
        }

        public abstract void use(Entity user, Entity target);

    }

    class HealthPotionItem : Item
    {
        public int healAmount;

        public HealthPotionItem(string name, string description, int shopPrice, int sellPrice, int healAmount) : base(name, description, shopPrice, sellPrice)
        {
            this.healAmount = healAmount;
        }

        public override void use(Entity user, Entity target)
        {
            target.currentHP += this.healAmount;
            Console.WriteLine(target.name + " healed themselves!");
        }
    }

    class ArmourItem : Item
    {
        public int defenseIncrease;

        public ArmourItem(string name, string description, int shopPrice, int sellPrice, int defenseIncrease) : base(name, description, shopPrice, sellPrice)
        {
            this.defenseIncrease = defenseIncrease;
        }

        public override void use(Entity user, Entity target)
        {
            target.currentDef += this.defenseIncrease;
            Console.WriteLine("You Equipped the armour!");
        }
    }

    class BoomStickItem : Item
    {
        public int damage;
        public int ammo;

        public BoomStickItem(string name, string description, int shopPrice, int sellPrice, int damage, int ammo) : base(name, description, shopPrice, sellPrice)
        {
            this.damage = damage;
            this.ammo = ammo;
        }

        public override void use(Entity user, Entity target)
        {
            if (this.ammo == 0)
                return;

            target.currentHP -= damage;
            --ammo;
            Console.WriteLine(target + " took " + damage + "boom damage!!!");
        }
    }
}
