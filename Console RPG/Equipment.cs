using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    abstract class Equipment : Item
    {
        public bool isEquipped;

        protected Equipment(string name, string description, int shopPrice, int sellPrice, bool isEquipped) : base(name, description, shopPrice, sellPrice)
        {
            this.isEquipped = isEquipped;
        }
    }

    class Armor : Equipment
    {
        public int defense;

        public Armor(string name, string description, int shopPrice, int sellPrice, bool isEquipped, int defense) : base(name, description, shopPrice, sellPrice, isEquipped)
        {
            this.defense = defense;
        }

        public override void use(Entity user, Entity target)
        {
            //flip whether or not it's equipped
            this.isEquipped = !this.isEquipped;

            if (this.isEquipped)
            {
                //if the armor isn't equipped, then equip it and iv=crease defense
                user.stats.defense += this.defense;
            }
            else
            {
                //if it's already equipped, then unequip it and decrease defense    
                user.stats.defense -= this.defense;
            }
        }
    }

    class Weapon : Equipment
    {
        public int damageIncrease;

        public Weapon(string name, string description, int shopPrice, int sellPrice, bool isEquipped, int damageIncrease) : base(name, description, shopPrice, sellPrice, isEquipped)
        {
            this.damageIncrease = damageIncrease;
        }

        public override void use(Entity user, Entity target)
        {
            //flip whether or not it's equipped
            this.isEquipped = !this.isEquipped;

            if (this.isEquipped)
            {
                //if the armor isn't equipped, then equip it and iv=crease defense
                user.stats.attack += this.damageIncrease;

                Console.WriteLine($"You equipped the {this.name}");
            }
            else
            {
                //if it's already equipped, then unequip it and decrease defense    
                user.stats.attack -= this.damageIncrease;

                Console.WriteLine($"You unequipped the {this.name}");
            }
        }
    }

    class Shard : Weapon
    {
        public int dmgToSelf;

        public Shard(string name, string description, int shopPrice, int sellPrice, bool isEquipped, int damageIncrease, int dmgToSelf) : base(name, description, shopPrice, sellPrice, isEquipped, damageIncrease)
        {
            this.dmgToSelf = dmgToSelf;
        }
    }
}
