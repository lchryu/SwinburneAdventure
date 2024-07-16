namespace SwinburneAdventure;
// using System;
//
// public class Program
// {
//     public static void Main(string[] args)
//     {
//         Console.Clear();
//         Console.Write("Enter your name: ");
//         string playerName = Console.ReadLine();
//
//         Console.Write("Enter your description: ");
//         string playerDescription = Console.ReadLine();
//
//         Player player = new Player(playerName, playerDescription);
//         
//         // Create initial location and assign to player (option)
//         Location startingLocation = new Location("Room", "A small room.");
//         player.CurrentLocation = startingLocation;
//         
//         
//         // Create items and add them to the player's inventory
//         Item sword = new Item(new string[] { "sword", "blade" }, "a bronze sword", "This is a mighty fi ne sword.");
//         Item gem = new Item(new string[] { "gem", "jewel" }, "a shiny gem", "This is a shiny gem.");
//         Bag bag = new Bag(new string[] { "bag", "sack" }, "a small bag", "This is a small bag.");
//
//         
//         startingLocation.Inventory.Put(gem);
//
//         
//         player.Inventory.Put(sword);
//         player.Inventory.Put(gem);
//         player.Inventory.Put(bag);
//
//         // Add an item to the bag
//         Item coin = new Item(new string[] { "coin", "gold" }, "a gold coin", "This is a shiny gold coin.");
//         bag.Inventory.Put(coin);
//
//         LookCommand lookCommand = new LookCommand();
//
//         while (true)        
//         {
//             Console.Write("\nCommand -> ");
//             string command = Console.ReadLine();
//             string[] commandParts = command.Split(' ');
//
//             if (commandParts[0].ToLower() == "quit")
//             {
//                 break;
//             }
//
//             string result = lookCommand.Execute(player, commandParts);
//             Console.WriteLine(result);
//         }
//     }
// }
public class Program
{
    public static void Main(string[] args)
    {
        Console.Clear();
        // Setup player and locations
        Console.Write("Enter your name: ");
        string playerName = Console.ReadLine();

        Console.Write("Enter your description: ");
        string playerDescription = Console.ReadLine();

        Player player = new Player(playerName, playerDescription);

        // Create initial locations
        Location startingRoom = new Location("Starting Room", "A starting room.");
        Location destinationRoom = new Location("Destination Room", "A destination room.");
        Location closet = new Location("Closet", "A small dark closet with an odd smell.");

        // Create paths
        Path northPath = new Path(new string[] { "north" }, destinationRoom);
        Path southPath = new Path(new string[] { "south" }, startingRoom);
        Path closetPath = new Path(new string[] { "south" }, closet);

        // Add paths to locations
        startingRoom.AddPath(northPath);
        startingRoom.AddPath(closetPath);
        destinationRoom.AddPath(southPath);

        // Assign the starting location to the player
        player.CurrentLocation = startingRoom;

        // Create items and add them to locations
        Item shovel = new Item(new string[] { "shovel" }, "a shovel", "This is a sturdy shovel.");
        Item bronzeSword = new Item(new string[] { "sword" }, "a bronze sword", "A short sword cast from bronze.");
        Item smallComputer = new Item(new string[] { "pc" }, "a small computer", "The light from the monitor of this computer illuminates the room.");

        startingRoom.Inventory.Put(shovel);
        startingRoom.Inventory.Put(bronzeSword);
        closet.Inventory.Put(smallComputer);

        // Create commands
        LookCommand lookCommand = new LookCommand();
        MoveCommand moveCommand = new MoveCommand();

        // Game loop
        while (true)
        {
            Console.Write($"\n{player.CurrentLocation.Name} -> ");
            string command = Console.ReadLine();
            string[] commandParts = command.Split(' ');

            if (commandParts[0].ToLower() == "quit")
            {
                break;
            }

            string result;
            switch (commandParts[0].ToLower())
            {
                case "look":
                    result = lookCommand.Execute(player, commandParts);
                    break;
                case "move":
                case "go":
                    result = moveCommand.Execute(player, commandParts);
                    break;
                default:
                    result = "I don't understand that command.";
                    break;
            }

            Console.WriteLine(result);
        }
    }
}
