namespace SwinburneAdventure;
[TestFixture]
public class Test_Location
{
    private Location _location;
    private Item _gem;

    [SetUp]
    public void Setup()
    {
        _location = new Location("Room", "A small room.");
        _gem = new Item(new string[] { "gem" }, "a shiny gem", "This is a shiny gem.");
        _location.Inventory.Put(_gem);
    }

    [Test]
    public void TestLocationIsIdentifiable()
    {
        Assert.IsTrue(_location.AreYou("location"));
        Assert.IsTrue(_location.AreYou("place"));
    }

    [Test]
    public void TestLocationLocatesItems()
    {
        Assert.AreEqual(_gem, _location.Locate("gem"));
    }

    [Test]
    public void TestLocationLocatesItself()
    {
        Assert.AreEqual(_location, _location.Locate("location"));
    }

    [Test]
    public void TestLocationLocatesNothing()
    {
        Assert.IsNull(_location.Locate("unknown"));
    }

    [Test]
    public void TestLocationFullDescription()
    {
        string description = "A small room.\nYou can see:\n\ta shiny gem (gem)\n";
        Assert.AreEqual(description, _location.FullDescription);
    }
}
