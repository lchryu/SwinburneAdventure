namespace SwinburneAdventure;

public class Location : GameObject, IHaveInventory
{
    private Inventory _inventory;

    public Location(string name, string desc) 
        : base(new string[] { "location", "place" }, name, desc)
    {
        _inventory = new Inventory();
    }

    public Inventory Inventory => _inventory;

    public override string FullDescription
    {
        get
        {
            return $"{base.FullDescription}\nYou can see:\n{_inventory.ItemList}";
        }
    }

    public GameObject Locate(string id)
    {
        if (this.AreYou(id))
            return this;

        return _inventory.Fetch(id);
    }
}
