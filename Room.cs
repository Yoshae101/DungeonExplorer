using System;
using System.Collections.Generic;
using DungeonExplorer;

namespace DungeonExplorer
{
    public class Room
    {
        private string description;
        public List<Location> Locations { get; private set; }

        public Room(string description)
        {
            this.description = description;
            // Create four locations with specific items.
            Locations = new List<Location>
            {
                new Location("Warped Wooden Table", "A creaky wooden table, scarred by time.", "Healing Chalice"),
                new Location("Used Armour Set on a Statue", "An old armour set resting on a broken statue.", "Shield"),
                new Location("Mural on the Wall", "A faded mural depicting ancient battles, with something glinting on its side.", "Key"),
                new Location("Next to the Throne", "A grand throne with a sword laid across its seat.", "Sword")
            };
        }

        public string GetDescription()
        {
            return description;
        }

        // Display a list of locations and check if an item is available.
        public void ShowLocations()
        {
            for (int i = 0; i < Locations.Count; i++)
            {
                string status = Locations[i].Item != null ? "Item available" : "Empty";
                Console.WriteLine($"{i + 1}. {Locations[i].Name} - {Locations[i].Description} ({status})");
            }
        }

        // Checks if any location still has an item.
        public bool HasRemainingItems()
        {
            foreach (var loc in Locations)
            {
                if (loc.Item != null)
                    return true;
            }
            return false;
        }

        // When a location is visited, pick up the item if available.
        public string PickUpItemFromLocation(int index)
        {
            Location loc = Locations[index];
            if (loc.Item != null)
            {
                Console.WriteLine($"\nYou travel to the {loc.Name} and find a {loc.Item}!");
                return loc.PickUpItem();
            }
            else
            {
                Console.WriteLine($"\nYou travel to the {loc.Name} but find nothing of value.");
                return null;
            }
        }
    }
}
