namespace SwinburneAdventure
{
    [TestFixture]
    public class Test_PickupCommand
    {
        private Player _player;
        private Location _startingRoom;
        private Item _sword;
        private PickupCommand _pickupCommand;

        [SetUp]
        public void Setup()
        {
            _startingRoom = new Location("Starting Room", "A starting room.");
            _player = new Player("John", "The mighty programmer");
            _player.CurrentLocation = _startingRoom;

            _sword = new Item(new string[] { "sword" }, "a bronze sword", "A short sword cast from bronze.");
            _startingRoom.Inventory.Put(_sword);

            _pickupCommand = new PickupCommand();
        }

        [Test]
        public void TestPickupItem()
        {
            string result = _pickupCommand.Execute(_player, new string[] { "pickup", "sword" });
            Assert.AreEqual(_player.Inventory.Fetch("sword"), _sword);
            Assert.AreEqual(result, "You have taken the a bronze sword from the Starting Room");
        }

        [Test]
        public void TestPickupItemFromNonExistentContainer()
        {
            string result = _pickupCommand.Execute(_player, new string[] { "pickup", "sword", "from", "bag" });
            Assert.AreEqual(result, "I cannot find the bag");
        }

        [Test]
        public void TestPickupNonExistentItem()
        {
            string result = _pickupCommand.Execute(_player, new string[] { "pickup", "nonexistent" });
            Assert.AreEqual(result, "I cannot find the nonexistent in the Starting Room");
        }
    }
}
