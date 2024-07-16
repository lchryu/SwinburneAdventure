namespace SwinburneAdventure;
using System;

public class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Enter your name: ");
        string playerName = Console.ReadLine();

        Console.Write("Enter your description: ");
        string playerDescription = Console.ReadLine();

        Player player = new Player(playerName, playerDescription);

        // Create items and add them to the player's inventory
        Item sword = new Item(new string[] { "sword", "blade" }, "a bronze sword", "This is a mighty fine sword.");
        Item gem = new Item(new string[] { "gem", "jewel" }, "a shiny gem", "This is a shiny gem.");
        Bag bag = new Bag(new string[] { "bag", "sack" }, "a small bag", "This is a small bag.");

        player.Inventory.Put(sword);
        player.Inventory.Put(gem);
        player.Inventory.Put(bag);

        // Add an item to the bag
        Item coin = new Item(new string[] { "coin", "gold" }, "a gold coin", "This is a shiny gold coin.");
        bag.Inventory.Put(coin);

        LookCommand lookCommand = new LookCommand();

        while (true)        
        {
            Console.Write("\nCommand -> ");
            string command = Console.ReadLine();
            string[] commandParts = command.Split(' ');

            if (commandParts[0].ToLower() == "quit")
            {
                break;
            }

            string result = lookCommand.Execute(player, commandParts);
            Console.WriteLine(result);
        }
    }
}
