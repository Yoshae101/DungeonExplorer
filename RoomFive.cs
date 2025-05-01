using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class RoomFive : Room
    {
        private string description;
        public List<Location> Locations { get; private set; }

        public RoomFive(string description) : base(description)
        {
            this.description = description;
            Locations = new List<Location>
            {
                new Location("Throne", "A grand throne, now empty, with the orc king waiting to face you.", null)
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

        // Encounter with the Orc King
        public void Encounter(Player player)
        {
            Orc orc = new Orc("Orc King", 150, 25);
            Battle.Start(player, orc);

            if (player.Health > 0)
            {
                Console.WriteLine("You have defeated the Orc King and completed your journey!");
            }
        }

        public void Enter(Player player)
        {
            Console.WriteLine(GetDescription() + "\n");

            Encounter(player);
            if (player.Health <= 0) return;

            while (HasRemainingItems())
            {
                Console.WriteLine("Choose a location to search:");
                ShowLocations();

                int choice = GetUserChoice(1, Locations.Count);
                var item = PickUpItemFromLocation(choice - 1);
                if (item != null)
                {
                    player.PickUpItem(item);
                }

                Console.WriteLine("\n" + player.GetStatus() + "\n");
            }

            Console.WriteLine("You have explored all of Room Five.\n");
        }

        private int GetUserChoice(int min, int max)
        {
            while (true)
            {
                Console.Write("Option: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int opt) && opt >= min && opt <= max)
                {
                    return opt;
                }
                Console.WriteLine($"Please enter a number between {min} and {max}.");
            }
        }
    }
}
