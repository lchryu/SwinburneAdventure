namespace SwinburneAdventure;

[TestFixture]
public class Test_Player
{
    [Test]
    public void TestPlayerIsIdentifiable()
    {
        Player player = new Player("Fred", "The mighty programmer");
        Assert.IsTrue(player.AreYou("me"));
        Assert.IsTrue(player.AreYou("inventory"));
    }

    [Test]
    public void TestPlayerLocatesItems()
    {
        Player player = new Player("Fred", "The mighty programmer");
        Item item = new Item(new string[] { "sword", "blade" }, "a bronze sword", "This is a mighty fine sword.");
        player.Inventory.Put(item);
        Assert.AreEqual(item, player.Locate("sword"));
    }

    [Test]
    public void TestPlayerLocatesItself()
    {
        Player player = new Player("Fred", "The mighty programmer");
        Assert.AreEqual(player, player.Locate("me"));
    }

    [Test]
    public void TestPlayerLocatesNothing()
    {
        Player player = new Player("Fred", "The mighty programmer");
        Assert.IsNull(player.Locate("nothing"));
    }

    [Test]
    public void TestPlayerFullDescription()
    {
        Player player = new Player("Fred", "The mighty programmer");
        Item item1 = new Item(new string[] { "sword", "blade" }, "a bronze sword", "This is a mighty fine sword.");
        Item item2 = new Item(new string[] { "shield", "armor" }, "a sturdy shield", "This is a strong shield.");
        player.Inventory.Put(item1);
        player.Inventory.Put(item2);
        Assert.AreEqual("You are Fred, The mighty programmer. You are carrying:\n\ta bronze sword (sword)\n\ta sturdy shield (shield)\n", player.FullDescription);
    }
}
