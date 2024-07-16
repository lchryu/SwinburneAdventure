namespace SwinburneAdventure;

[TestFixture]
public class Test_Item
{
    [Test]
    public void TestItemIsIdentifiable()
    {
        Item item = new Item(new string[] { "sword", "blade" }, "a bronze sword", "This is a mighty fine sword.");
        Assert.IsTrue(item.AreYou("sword"));
        Assert.IsTrue(item.AreYou("blade"));
    }

    [Test]
    public void TestShortDescription()
    {
        Item item = new Item(new string[] { "sword", "blade" }, "a bronze sword", "This is a mighty fine sword.");
        Assert.AreEqual("a bronze sword (sword)", item.ShortDescription);
    }

    [Test]
    public void TestFullDescription()
    {
        Item item = new Item(new string[] { "sword", "blade" }, "a bronze sword", "This is a mighty fine sword.");
        Assert.AreEqual("This is a mighty fine sword.", item.FullDescription);
    }
}
