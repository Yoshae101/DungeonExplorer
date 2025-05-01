using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class RoomTwo : Room
    {
        private string description;
        public List<Location> Locations { get; private set; }

        public RoomTwo(string description) : base(description)
        {
            this.description = description;
            Locations = new List<Location>
            {
                new Location("Benches", "A few benches with some broken plates around.", "Health Potion"),
                new Location("Broken Plates", "Rusty and old plates scattered on the floor.", "Chestplate")
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

        public void Encounter(Player player) // Creates the battle event
        {
            Orc orc = new Orc("Orc Grunt", 20, 5);
            Battle.Start(player, orc);

            if (player.Health > 0)
            {
                Console.WriteLine("The orc drops a health potion! You can pick it up.");
                PickUpItemFromLocation(0); // Auto-pick health potion from Benches
            }
        }

        public void Enter(Player player) // Allows the player to enter the room 
        {
            Console.WriteLine(GetDescription());
            Encounter(player);
            if (player.Health <= 0) return;

            while (HasRemainingItems() && player.Health > 0)
            {
                Console.WriteLine("\nChoose a location to search:");
                ShowLocations();
                Console.Write("Option: ");
                if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= Locations.Count)
                {
                    var item = PickUpItemFromLocation(choice - 1);
                    if (item != null)
                    {
                        player.PickUpItem(item);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input!");
                }
            }

            Console.WriteLine("You Rummage Around But Can't Find Anything More Of Value In The Cafeteria");
        }
    }
}
