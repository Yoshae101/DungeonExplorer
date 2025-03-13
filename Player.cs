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

        public string Name
        {
            get { return name; }
        }

        public int Health
        {
            get { return health; }
            set { health = value < 0 ? 0 : value; }
        }

        public void PickUpItem(string item)
        {
            inventory.Add(item);
            Console.WriteLine($"{name} picked up {item}.");
        }

        public string GetStatus()
        {
            string invStatus = (inventory.Count > 0) ? string.Join(", ", inventory) : "No items";
            return $"Player: {name}\nHealth: {health}\nInventory: {invStatus}";
        }
    }
}
