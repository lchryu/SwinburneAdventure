﻿namespace SwinburneAdventure;

public class Bag : Item, IHaveInventory
{
    private Inventory _inventory;

    public Bag(string[] ids, string name, string desc)
        : base(ids, name, desc)
    {
        _inventory = new Inventory();
    }

    public Inventory Inventory => _inventory;

    public override string FullDescription
    {
        get
        {
            return $"{base.FullDescription}\nIn the {Name} you can see:\n{_inventory.ItemList}";
        }
    }

    public GameObject Locate(string id)
    {
        if (AreYou(id))
        {
            return this;
        }
        return _inventory.Fetch(id);
    }

    public void Put(Item item)
    {
        _inventory.Put(item);
    }

    public Item Take(string id)
    {
        return _inventory.Take(id);
    }
}
