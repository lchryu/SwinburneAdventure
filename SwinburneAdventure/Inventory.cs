namespace SwinburneAdventure;

public class Inventory
{
    private List<Item> _items;

    public Inventory()
    {
        _items = new List<Item>();
    }

    public bool HasItem(string id)
    {
        foreach (Item item in _items)
        {
            if (item.AreYou(id)) return true;
        }
        return false;
    }

    public void Put(Item item) => _items.Add(item);

    public Item Fetch(string id)
    {
        foreach (Item item in _items)
        {
            if (item.AreYou(id)) return item;
        }
        return null;
    }

    public Item Take(string id)
    {
        Item item = Fetch(id);
        if (item != null) _items.Remove(item);
        return item;
    }

    public string ItemList
    {
        get
        {
            string itemList = string.Empty;
            foreach (Item item in _items) itemList += $"\t{item.ShortDescription}\n";
            return itemList;
        }
    }
    
    // ++
    public List<Item> Items => _items;
}