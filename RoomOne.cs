using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class RoomOne : Room
    {
        private string description;
        public List<Location> Locations { get; private set; }

        public RoomOne(string description) : base(description)
        {
            this.description = description;
            Locations = new List<Location> // Creates The POIs in Room One
            {
                new Location("Weapon Rack", "A rack filled with rusted weapons, but something glints among them.", "Old Sword"),
                new Location("Wooden Crate", "A battered crate with something inside.", "Shield"),
                new Location("Armor Stand", "A broken suit of armor that might still have useful parts.", "Helmet"),
                new Location("Wall Hooks", "Hooks that once held weapons. One still hangs there.", "Throne Room Key")
            };
        }

        public string GetDescription() => description;

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
