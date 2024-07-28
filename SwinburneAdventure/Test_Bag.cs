namespace SwinburneAdventure;

[TestFixture]
public class BagTests
{
    [Test]
    public void TestBagIsIdentifiable()
    {
        Bag bag = new Bag(new string[] { "bag" }, "a small bag", "This is a small bag.");
        Assert.IsTrue(bag.AreYou("bag"));
    }

    [Test]
    public void TestBagLocatesItems()
    {
        Bag bag = new Bag(new string[] { "bag" }, "a small bag", "This is a small bag.");
        Item sword = new Item(new string[] { "sword" }, "a bronze sword", "This is a mighty fine sword.");
        bag.Inventory.Put(sword);
        Assert.AreEqual(sword, bag.Locate("sword"));
    }

    [Test]
    public void TestBagLocatesItself()
    {
        Bag bag = new Bag(new string[] { "bag" }, "a small bag", "This is a small bag.");
        Assert.AreEqual(bag, bag.Locate("bag"));
    }

    [Test]
    public void TestBagLocatesNothing()
    {
        Bag bag = new Bag(new string[] { "bag" }, "a small bag", "This is a small bag.");
        Assert.IsNull(bag.Locate("sword"));
    }

    [Test]
    public void TestBagFullDescription()
    {
        Bag bag = new Bag(new string[] { "bag" }, "a small bag", "This is a small bag.");
        Item sword = new Item(new string[] { "sword" }, "a bronze sword", "This is a mighty fine sword.");
        bag.Inventory.Put(sword);
        Assert.AreEqual("This is a small bag.\nIn the a small bag you can see:\n\ta bronze sword (sword)\n", bag.FullDescription);
    }


    [Test]
    public void TestBagInBag()
    {
        Bag bag1 = new Bag(new string[] { "bag1" }, "a large bag", "This is a large bag.");
        Bag bag2 = new Bag(new string[] { "bag2" }, "a small bag", "This is a small bag.");
        Item sword = new Item(new string[] { "sword" }, "a bronze sword", "This is a mighty fine sword.");
        Item item1 = new Item(new string[] { "item1" }, "an item", "This is an item.");
        Item item2 = new Item(new string[] { "item2" }, "another item", "This is another item.");

        bag2.Inventory.Put(sword);
        bag1.Inventory.Put(bag2);
        bag1.Inventory.Put(item1);
        bag2.Inventory.Put(item2);

        // Check that bag1 can find bag2
        Assert.AreEqual(bag2, bag1.Locate("bag2"));

        // Check that bag1 cannot find sword in bag2
        Assert.IsNull(bag1.Locate("sword"));

        // Check that bag1 can find item1 in bag1
        Assert.AreEqual(item1, bag1.Locate("item1"));

        // Check that bag2 cannot find item1 in bag1
        Assert.IsNull(bag2.Locate("item1"));

        // Check that bag1 cannot directly find item2 in bag2
        Assert.IsNull(bag1.Locate("item2"));

    }
}
