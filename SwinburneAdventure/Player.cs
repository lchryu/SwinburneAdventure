namespace SwinburneAdventure;

public class Player:GameObject,IHaveInventory
{
    private Inventory _inventory;
    private Location _currentLocation;
    public Player(string name, string desc)
        : base(new string[] {"me", "inventory"}, name, desc)
    {
        _inventory = new ();
        _currentLocation = new Location("Room", "A small room.");
    }
    public Inventory Inventory => _inventory;
    public Location CurrentLocation
    {
        get => _currentLocation;
        set => _currentLocation = value;
    }
    public override string FullDescription
    {
        get
        {
            return $"You are {Name}, {base.FullDescription}. You are carrying:\n{_inventory.ItemList}\nYou are in {CurrentLocation.Name}:\n{CurrentLocation.FullDescription}";
        }
    }

    public GameObject Locate(string id)
    {
        if (this.AreYou(id))
            return this;

        GameObject foundItem = _inventory.Fetch(id);
        if (foundItem != null)
            return foundItem;

        return CurrentLocation.Locate(id);
    }
}