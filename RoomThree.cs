using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class RoomThree : Room
    {
        private string description;
        public List<Location> Locations { get; private set; }

        public RoomThree(string description) : base(description)
        {
            this.description = description;
            Locations = new List<Location>
            {
                new Location("Forge", "A large forge with glowing embers and unfinished weapons.", "Health Potion"),
                new Location("Work Bench", "A workbench with a sword resting on it, waiting for refinement.", "Strong Sword")
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

        public void Encounter(Player player)
        {
            Orc orc = new Orc("Orc Soldier", 70, 15);
            Battle.Start(player, orc);

            if (player.Health > 0)
            {
                Console.WriteLine("The orc drops a healing potion and a sword! You can pick them up.");
                PickUpItemFromLocation(0);
                PickUpItemFromLocation(1);
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

            Console.WriteLine("You Push Over The Hot Iron Tools However Cant Find Anything Else Worth Gathering.\n");
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
