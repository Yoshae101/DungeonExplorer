using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        private string name;
        private int health;
        private List<string> inventory;

        public Player(string name, int health)
        {
            this.name = name;
            this.Health = health;
            inventory = new List<string>();
        }

        public string Name { get { return name; } }

        public int Health
        {
            get { return health; }
            set { health = value < 0 ? 0 : value; }
        }

        public void PickUpItem(string item)
        {
            inventory.Add(item);
            Console.WriteLine($"{name} picked up {item}.");

            // Picking up armour increases health
            if (item == "Helmet")
            {
                Health += 25;
                Console.WriteLine("The Orc's Helmet Fits Your Head Perfectly - Your Health Increased by 25!");
            }
            if (item == "Chestplate")
            {
                Health += 50;
                Console.WriteLine("Its A Squeeze To Get Into However ... It fits - Your Health Increased by 50");

            }

            if (item == "Health Potion")
            {
                int healAmount = 75; // Heal amount for health potion
                Health += healAmount;
                Console.WriteLine($"You Gulp Down The Healing Potion - It Tastes Horrible But Your Wounds Heal - Your health restored by 75");
            }
        }

        public string GetStatus()
        {
            string invStatus = (inventory.Count > 0) ? string.Join(", ", inventory) : "No items";
            return $"Player: {name}\nHealth: {health}\nInventory: {invStatus}";
        }

        public int GetAttackDamage()
        {
            int damage = 10; // Default damage
            if (inventory.Contains("Strong Sword"))
                damage += 15;  // Additional damage from Strong Sword
            return damage;
        }
    }
}
