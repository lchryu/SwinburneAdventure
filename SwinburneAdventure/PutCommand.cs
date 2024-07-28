namespace SwinburneAdventure;

public class PutCommand : Command
{
    public PutCommand() : base(new string[] { "put", "drop" })
    {
    }

    public override string Execute(Player p, string[] text)
    {
        if (text.Length != 2 && text.Length != 4)
        {
            return "I don't know how to put like that.";
        }

        string itemId = text[1].ToLower();
        IHaveInventory container = null;

        if (text.Length == 4)
        {
            if (text[2].ToLower() != "in")
            {
                return "Where do you want to put the item?";
            }
            container = FetchContainer(p, text[3]);
            if (container == null)
            {
                return $"I cannot find the {text[3]}";
            }
        }
        else
        {
            container = p.CurrentLocation;
        }

        GameObject item = p.Inventory.Fetch(itemId);
        if (item == null)
        {
            return $"You are not carrying a {itemId}";
        }

        if (item is Item)
        {
            p.Inventory.Take(itemId);
            container.Inventory.Put(item as Item);
            return $"You have put the {item.Name} in the {container.Name}";
        }

        return $"The {itemId} cannot be put there.";
    }

    private IHaveInventory FetchContainer(Player p, string containerId)
    {
        GameObject obj = p.Locate(containerId);
        return obj as IHaveInventory;
    }
}
