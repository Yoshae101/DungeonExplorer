using System;

namespace DungeonExplorer
{
    public static class Battle // When enounter is called he battle is initiated
    {
        private static Random rng = new Random();

        public static void Start(Player player, Orc orc)
        {
            Console.WriteLine($"\nA wild {orc.Name} appears! Prepare for battle!\n");

            while (player.Health > 0 && orc.Health > 0)
            {
                Console.WriteLine("Your Turn:");
                Console.WriteLine("1. Attack");
                Console.WriteLine("2. Block");
                Console.Write("Choose your action: ");
                string input = Console.ReadLine();
                int playerDamage = player.GetAttackDamage();

                bool playerBlocked = false;

                switch (input)
                {
                    case "1":
                        if (rng.NextDouble() < 0.1) // Creates a potential for YOU to miss an attack
                        {
                            Console.WriteLine("You missed your attack!");
                        }
                        else
                        {
                            if (rng.NextDouble() < 0.2) // Creates a potential that the orc blocks your attack
                            {
                                Console.WriteLine($"{orc.Name} blocked your attack!");
                            }
                            else
                            {
                                orc.Health -= playerDamage; // Player Deals Damage to Orc
                                Console.WriteLine($"You hit the {orc.Name} for {playerDamage} damage.\n");
                            }
                        }
                        break;
                    case "2":
                        playerBlocked = true;
                        Console.WriteLine("You brace yourself and prepare to block the next attack.\n");
                        break;
                    default:
                        Console.WriteLine("Invalid input. You lost your turn.");
                        break;
                }

                if (orc.Health <= 0) break;

                Console.WriteLine("Enemy Turn:");
                if (rng.NextDouble() < 0.1) // Creates A Potential For The Orc To Miss An Attack
                {
                    Console.WriteLine($"{orc.Name} missed their attack!\n");
                }
                else
                {
                    int damage = orc.Damage;
                    if (playerBlocked)
                    {
                        damage /= 2;
                        Console.WriteLine($"You partially blocked the attack! You receive {damage} damage.");
                    }
                    else
                    {
                        Console.WriteLine($"{orc.Name} hits you for {damage} damage.");
                    }
                    player.Health -= damage;
                }

                Console.WriteLine($"\nPlayer Health: {player.Health}");
                Console.WriteLine($"{orc.Name} Health: {orc.Health}\n");
            }

            if (player.Health > 0)
                Console.WriteLine($"You defeated the {orc.Name}!");
            else
                Console.WriteLine("You were defeated. Game Over.");

            Console.WriteLine();
        }
    }
}
