namespace Console_RPG
{
    struct Stats
    {
        public int attack;
        public int defense;
        public int magicAtk;
        public int magicDef;

        public Stats(int attack, int defense, int magicAtk, int magicDef)
        {
            this.attack = attack;
            this.defense = defense;
            this.magicAtk = magicAtk;
            this.magicDef = magicDef;
        }
    }
}
