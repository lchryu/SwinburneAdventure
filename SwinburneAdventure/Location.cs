namespace SwinburneAdventure;

public class Location : GameObject, IHaveInventory
{
    private Inventory _inventory;
    private List<Path> _paths;
    public Location(string name, string desc) 
        : base(new string[] { "location", "place" }, name, desc)
    {
        _inventory = new Inventory();
        _paths = new List<Path>();
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
    public void AddPath(Path path)
    {
        _paths.Add(path);
    }
    public Path GetPath(string direction)
    {
        foreach (var path in _paths)
        {
            if (path.AreYou(direction))
                return path;
        }
        return null;
    }
}
