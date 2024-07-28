namespace SwinburneAdventure
{
    public class Program
    {
        public static void Main(string[] args)
        {
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
            Path closetPathFromStartingRoom = new Path(new string[] { "east" }, closet);
            Path closetPathToStartingRoom = new Path(new string[] { "west" }, startingRoom);

            // Add paths to locations
            startingRoom.AddPath(northPath);
            startingRoom.AddPath(closetPathFromStartingRoom);
            destinationRoom.AddPath(southPath);
            closet.AddPath(closetPathToStartingRoom);

            // Assign the starting location to the player
            player.CurrentLocation = startingRoom;

            // Create items and add them to locations
            Item shovel = new Item(new string[] { "shovel" }, "a shovel", "This is a sturdy shovel.");
            Item bronzeSword = new Item(new string[] { "sword" }, "a bronze sword", "A short sword cast from bronze.");
            Item smallComputer = new Item(new string[] { "pc" }, "a small computer", "The light from the monitor of this computer illuminates the room.");

            startingRoom.Inventory.Put(shovel);
            startingRoom.Inventory.Put(bronzeSword);
            closet.Inventory.Put(smallComputer);

            // Create a bag and add it to the player's inventory
            Bag bag = new Bag(new string[] { "bag" }, "a small bag", "This is a small bag.");
            player.Inventory.Put(bag);

            // Create commands
            CommandProcessor commandProcessor = new CommandProcessor();
            commandProcessor.RegisterCommand(new LookCommand());
            commandProcessor.RegisterCommand(new MoveCommand());
            commandProcessor.RegisterCommand(new PickupCommand());
            commandProcessor.RegisterCommand(new PutCommand());

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

                string result = commandProcessor.ExecuteCommand(player, commandParts);
                Console.WriteLine(result);
            }
        }
    }
}
