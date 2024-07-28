namespace SwinburneAdventure
{
    [TestFixture]
    public class Test_PutCommand
    {
        private Player _player;
        private Location _startingRoom;
        private Bag _bag;
        private Item _sword;
        private PutCommand _putCommand;

        [SetUp]
        public void Setup()
        {
            _startingRoom = new Location("Starting Room", "A starting room.");
            _player = new Player("John", "The mighty programmer");
            _player.CurrentLocation = _startingRoom;

            _sword = new Item(new string[] { "sword" }, "a bronze sword", "A short sword cast from bronze.");
            _bag = new Bag(new string[] { "bag" }, "a small bag", "This is a small bag.");

            _player.Inventory.Put(_sword);
            _player.Inventory.Put(_bag);

            _putCommand = new PutCommand();
        }

        [Test]
        public void TestPutItemInBag()
        {
            string result = _putCommand.Execute(_player, new string[] { "put", "sword", "in", "bag" });
            Assert.AreEqual(_bag.Inventory.Fetch("sword"), _sword);
            Assert.AreEqual(result, "You have put the a bronze sword in the a small bag");
        }

        [Test]
        public void TestPutItemInNonExistentContainer()
        {
            string result = _putCommand.Execute(_player, new string[] { "put", "sword", "in", "nonexistent" });
            Assert.AreEqual(result, "I cannot find the nonexistent");
        }

        [Test]
        public void TestPutNonExistentItem()
        {
            string result = _putCommand.Execute(_player, new string[] { "put", "nonexistent", "in", "bag" });
            Assert.AreEqual(result, "You are not carrying a nonexistent");
        }
    }
}
