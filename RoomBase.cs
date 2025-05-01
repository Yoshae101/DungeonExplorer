using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public abstract class Room // Base Class For Room Makes Rooms Accessible From The Game.cs Script
    {
        public string Description { get; protected set; }
        public List<Location> Locations { get; private set; }

        public Room(string description)
        {
            Description = description;
            Locations = new List<Location>();
        }

        public void ShowLocations()
        {
            for (int i = 0; i < Locations.Count; i++)
            {
                var loc = Locations[i];
                string status = loc.Item != null ? "Item available" : "Empty";
                Console.WriteLine($"{i + 1}. {loc.Name} - {loc.Description} ({status})");
            }
        }

        public bool HasRemainingItems() => Locations.Exists(loc => loc.Item != null);

        public string PickUpItemFromLocation(int index)
        {
            var loc = Locations[index];
            if (loc.Item != null)
            {
                Console.WriteLine($"\nYou search the {loc.Name} and find a {loc.Item}!");
                return loc.PickUpItem();
            }
            Console.WriteLine($"\nYou search the {loc.Name} but find nothing.");
            return null;
        }
    }
}
