﻿using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    abstract class Entity
    {
        public string name;

        public float currentHP, maxHP;
        public float currentMana, maxMana;

        //Composition
        public Stats stats;

        public Entity(string name, float hp, float mana, Stats stats)
        {
            this.name = name;
            this.currentHP = hp;
            this.maxHP = hp;
            this.currentMana = mana;
            this.maxMana = mana;
            this.stats = stats;



        }

        public abstract Entity Choosetarget(List<Entity> choices);

        public abstract void Attack(Entity target);


    }
}