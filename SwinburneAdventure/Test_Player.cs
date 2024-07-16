namespace SwinburneAdventure;

[TestFixture]
public class Test_Player
{
 private Player _player;
    private Location _room;
    private Item _gem;

    [SetUp]
    public void Setup()
    {
        _player = new Player("Fred", "The mighty programmer");
        _room = new Location("Room", "A small room.");
        _player.CurrentLocation = _room;

        _gem = new Item(new string[] { "gem" }, "a shiny gem", "This is a shiny gem.");
        _room.Inventory.Put(_gem);
    }

    [Test]
    public void TestPlayerIsIdentifiable()
    {
        Assert.IsTrue(_player.AreYou("me"));
        Assert.IsTrue(_player.AreYou("inventory"));
    }

    [Test]
    public void TestPlayerLocatesItemsInInventory()
    {
        Item sword = new Item(new string[] { "sword" }, "a bronze sword", "This is a mighty fine sword.");
        _player.Inventory.Put(sword);
        Assert.AreEqual(sword, _player.Locate("sword"));
    }

    [Test]
    public void TestPlayerLocatesItemsInLocation()
    {
        Assert.AreEqual(_gem, _player.Locate("gem"));
    }

    [Test]
    public void TestPlayerLocatesItself()
    {
        Assert.AreEqual(_player, _player.Locate("me"));
    }

    [Test]
    public void TestPlayerLocatesNothing()
    {
        Assert.IsNull(_player.Locate("unknown"));
    }

    [Test]
    public void TestPlayerFullDescription()
    {
        string description = "You are Fred, The mighty programmer. You are carrying:\n\nYou are in Room:\nA small room.\nYou can see:\n\ta shiny gem (gem)\n";
        string actualDescription = _player.FullDescription;
        // Console.WriteLine($"Expected: {description}");
        // Console.WriteLine($"Actual: {actualDescription}");
        Assert.AreEqual(description, actualDescription);
    }

}
