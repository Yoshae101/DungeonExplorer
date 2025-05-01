using System;

namespace DungeonExplorer
{
    public class Location
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Item { get; private set; }

        public Location(string name, string description, string item) //Class For Creating POIs in Rooms
        {
            Name = name;
            Description = description;
            Item = item;
        }

        public string PickUpItem() // Allows the player to pick up items
        {
            string foundItem = Item;
            Item = null;
            return foundItem;
        }
    }
}

