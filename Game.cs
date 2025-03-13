using System;

namespace DungeonExplorer
{
    public class Game
    {
        private Player player;
        private Room currentRoom;

        public Game()
        {
            // Initialize player with a name and starting health.
            Console.Write("Enter your name: ");
            string playerName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(playerName))
            {
                Console.WriteLine("Name cannot be empty. Using default name 'Steve'.");
                playerName = "Steve";
            }
            player = new Player(playerName, 100);

            // Create the room with the provided description.
            currentRoom = new Room(
                "As you push open the rustic wooden doors, the air thickens. The Orcs throne glistens from the dying flame in the centre of the floor. " +
                "The rugged red carpet underneath your feet tears as you tread into the room, the breeze from the hall follows you in giving life back to the now roaring fire. " +
                "The room, now engulfed in a flickering light, uncovers the throne room from its dark veil ... you decide to explore the room."
            );
        }

        public void Start()
        {
            Console.WriteLine("\nGame started...\n");

            // Display the room's description.
            Console.WriteLine(currentRoom.GetDescription());
            Console.WriteLine();

            // Show travel options until all items have been collected.
            while (currentRoom.HasRemainingItems())
            {
                Console.WriteLine("Where would you like to check out? Choose an option by number:");
                currentRoom.ShowLocations();

                int choice = GetUserChoice();
                // Valid index check (user enters 1-4)
                if (choice < 1 || choice > currentRoom.Locations.Count)
                {
                    Console.WriteLine("Invalid option. Please choose a valid number.");
                    continue;
                }

                // Pick up the item (if available) from the chosen location.
                string itemFound = currentRoom.PickUpItemFromLocation(choice - 1);
                if (itemFound != null)
                {
                    player.PickUpItem(itemFound);
                }
                Console.WriteLine("\nPlayer Status:");
                Console.WriteLine(player.GetStatus());
                Console.WriteLine();
            }

            Console.WriteLine("All items have been collected. You have explored every location!");
            Console.WriteLine("Press any key to exit the game.");
            Console.ReadKey();
        }

        private int GetUserChoice()
        {
            Console.Write("Option: ");
            string input = Console.ReadLine();
            int option;
            if (int.TryParse(input, out option))
            {
                return option;
            }
            return -1;
        }
    }
}

