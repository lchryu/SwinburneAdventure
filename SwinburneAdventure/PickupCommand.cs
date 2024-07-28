namespace SwinburneAdventure;

public class PickupCommand : Command
{
    public PickupCommand() : base(new string[] { "pickup", "take" })
    {
    }

    public override string Execute(Player p, string[] text)
    {
        if (text.Length != 2 && text.Length != 4)
        {
            return "I don't know how to pick up like that.";
        }

        string itemId = text[1].ToLower();
        IHaveInventory container = null;

        if (text.Length == 4)
        {
            if (text[2].ToLower() != "from")
            {
                return "What do you want to pick up from?";
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

        GameObject item = container.Locate(itemId);
        if (item == null)
        {
            return $"I cannot find the {itemId} in the {container.Name}";
        }

        if (item is Item)
        {
            container.Inventory.Take(itemId);
            p.Inventory.Put(item as Item);
            return $"You have taken the {item.Name} from the {container.Name}";
        }

        return $"The {itemId} cannot be picked up.";
    }

    private IHaveInventory FetchContainer(Player p, string containerId)
    {
        GameObject obj = p.Locate(containerId);
        return obj as IHaveInventory;
    }
}
