namespace SwinburneAdventure;

[TestFixture]
public class Test_LookCommand

{
    private Player _player;
    private Bag _bag;
    private Item _gem;
    private LookCommand _lookCommand;

    [SetUp]
    public void Setup()
    {
        _player = new Player("Fred", "The mighty programmer");
        _bag = new Bag(new string[] { "bag" }, "a small bag", "This is a small bag.");
        _gem = new Item(new string[] { "gem" }, "a shiny gem", "This is a shiny gem.");
        _player.Inventory.Put(_bag);
        _player.Inventory.Put(_gem);
        _lookCommand = new LookCommand();
    }

    [Test]
    public void TestLookAtMe()
    {
        string result = _lookCommand.Execute(_player, new string[] { "look", "at", "inventory" });
        Assert.AreEqual(_player.FullDescription, result);
    }

    [Test]
    public void TestLookAtGem()
    {
        string result = _lookCommand.Execute(_player, new string[] { "look", "at", "gem" });
        Assert.AreEqual(_gem.FullDescription, result);
    }

    [Test]
    public void TestLookAtUnknownItem()
    {
        string result = _lookCommand.Execute(_player, new string[] { "look", "at", "unknown" });
        Assert.AreEqual(
            "I cannot find the unknown in the Fred",
            result
        );
    }

    [Test]
    public void TestLookAtGemInBag()
    {
        _bag.Inventory.Put(_gem);
        string result = _lookCommand.Execute(
            _player, 
            new string[] { "look", "at", "gem", "in", "bag" }
        );
        Assert.AreEqual(
            _gem.FullDescription,
            result
        );
    }

    [Test]
    public void TestLookAtGemInUnknownBag()
    {
        string result = _lookCommand.Execute(_player, new string[] { "look", "at", "gem", "in", "unknownbag" });
        Assert.AreEqual("I cannot find the unknownbag", result);
    }

    [Test]
    public void TestInvalidLookCommand()
    {
        string result = _lookCommand.Execute(_player, new string[] { "look", "around" });
        Assert.AreEqual("I don’t know how to look like that", result);
    }
}
