using System;
using DungeonExplorer;

namespace DungeonExplorer
{
    public class Orc // Enemy Class 
    {
        public string Name { get; private set; }
        public int Health { get; set; }
        public int Damage { get; private set; }

        public Orc(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }



        // Specifying Which Orcs Can Spawn In
        public class OrcGrunt : Orc
        {
            public OrcGrunt() : base("Orc Grunt", 20, 5) { }
        }

        public class OrcSoldier : Orc
        {
            public OrcSoldier() : base("Orc Soldier", 70, 15) { }
        }

        public class OrcWarlord : Orc
        {
            public OrcWarlord() : base("Orc Warlord", 100, 20) { }
        }

        public class OrcKing : Orc
        {
            public OrcKing() : base("Orc King", 150, 25) { }
        }
    }
}

