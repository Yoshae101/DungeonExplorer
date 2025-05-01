using System;
using System.Runtime.InteropServices;

namespace DungeonExplorer
{
    public class Game
    {
        private Player player;
        private RoomOne roomOne;
        private RoomTwo roomTwo;
        private RoomThree roomThree;
        private RoomFour roomFour;
        private RoomFive roomFive;

        public Game()
        {
            Console.Write("Enter your name: ");
            string playerName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(playerName))
            {
                Console.WriteLine("Name cannot be empty. Using default name 'Steve'.");
                playerName = "Steve";
            }
            player = new Player(playerName, 100);
            roomOne = new RoomOne("\n You Slowly Push The Dungeon Doors Open Stumbling Down The Rocky Cavern, The Torch Lit Halls Flicker With Light\n " 
                + " You Reach A Wooden Door Which Swings Open To The Orcs Armoury - Bloodstained Weapons Are Hung on the wall but they still flicker with light \n" 
                + "You peer around the corner two old armour stands are idle in the room the armour looking new and polished untouched by war \n" +
                "... You delve into the room to see whats around ..."); ;
            roomTwo = new RoomTwo("\n You Pull Open A Door Handle, Its Rusted Iron Handle Chips In Your Hand It Opens Revealing A Cafeteria With An Orc Finishing Off His Meal \n");
            roomThree = new RoomThree("\n You Hear Metal Clanging Through The Door You Rush Through Clutching Your Sword To See What Thw Noise Is -"
                +"\n An Orc Drops His Tools And Grabs The Strong Sword He Has Just Finished Tempering \n");
            roomFour = new RoomFour("The Blacksmiths Go Silent As The Flames Burn Out, A Chime Comes From A Door With A Cross On\n"+
                "You Tap The Door With Your New Sword As It Swings Open Revealing the Orcs Church");
            roomFive = new RoomFive("The Guard Topples Over Making A Horriffic Screach - You Hear A Massive Pound Come From The Double Doors Off to the Side \n"+
                "You Jam The Key You Found In the Armoury Into The Lock And With A Hard Twist The Doors Swing Open Revealing The King And His Throne");
        }

        public void Start()
        {
            Console.WriteLine("\n--- Room One: The Armory ---\n");
            Console.WriteLine(roomOne.GetDescription() + "\n");

            while (roomOne.HasRemainingItems())
            {
                Console.WriteLine("Choose a location to search:");
                roomOne.ShowLocations();
                int choice = GetUserChoice(1, roomOne.Locations.Count);
                var item = roomOne.PickUpItemFromLocation(choice - 1);
                if (item != null)
                {
                    player.PickUpItem(item);
                }
                Console.WriteLine("\n" + player.GetStatus() + "\n");
            }
            Console.WriteLine("You collected all items in Room One.\n");

            Console.WriteLine("\n--- Room Two: Cafeteria ---\n");
            roomTwo.Enter(player);
            if (player.Health <= 0) return;

            Console.WriteLine("\n--- Room Three: Blacksmith's Forge ---\n");
            roomThree.Enter(player);
            if (player.Health <= 0) return;

            Console.WriteLine("\n--- Room Four: The Church ---\n");
            roomFour.Enter(player);
            if (player.Health <= 0) return;

            Console.WriteLine("\n--- Room Five: Throne Room ---\n");
            roomFive.Enter(player);
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