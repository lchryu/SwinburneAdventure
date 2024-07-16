namespace SwinburneAdventure;
[TestFixture]
public class Test_Inventory
{
    [Test]
    public void TestFindItem()
    {
        Inventory inventory = new Inventory();
        Item item = new Item(new string[] { "sword", "blade" }, "a bronze sword", "This is a mighty fine sword.");
        inventory.Put(item);
        Assert.IsTrue(inventory.HasItem("sword"));
    }

    [Test]
    public void TestNoItemFind()
    {
        Inventory inventory = new Inventory();
        Assert.IsFalse(inventory.HasItem("sword"));
    }

    [Test]
    public void TestFetchItem()
    {
        Inventory inventory = new Inventory();
        Item item = new Item(new string[] { "sword", "blade" }, "a bronze sword", "This is a mighty fine sword.");
        inventory.Put(item);
        Assert.AreEqual(item, inventory.Fetch("sword"));
        Assert.IsTrue(inventory.HasItem("sword"));
    }

    [Test]
    public void TestTakeItem()
    {
        Inventory inventory = new Inventory();
        Item item = new Item(new string[] { "sword", "blade" }, "a bronze sword", "This is a mighty fine sword.");
        inventory.Put(item);
        Assert.AreEqual(item, inventory.Take("sword"));
        Assert.IsFalse(inventory.HasItem("sword"));
    }

    [Test]
    public void TestItemList()
    {
        Inventory inventory = new Inventory();
        Item item1 = new Item(new string[] { "sword", "blade" }, "a bronze sword", "This is a mighty fine sword.");
        Item item2 = new Item(new string[] { "shield", "armor" }, "a sturdy shield", "This is a strong shield.");
        inventory.Put(item1);
        inventory.Put(item2);
        Assert.AreEqual("\ta bronze sword (sword)\n\ta sturdy shield (shield)\n", inventory.ItemList);
    }
}
