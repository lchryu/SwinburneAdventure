﻿namespace SwinburneAdventure;

public class LookCommand : Command
{
    public LookCommand() : base(new string[] { "look" })
    {
    }

    public override string Execute(Player p, string[] text)
    {
        if (text.Length == 1)
        {
            return p.CurrentLocation.FullDescription;
        }

        if (text.Length != 3 && text.Length != 5)
        {
            return "I don’t know how to look like that";
        }

        if (text[0] != "look")
        {
            return "Error in look input";
        }

        if (text[1] != "at")
        {
            return "What do you want to look at?";
        }

        if (text.Length == 5 && text[3] != "in")
        {
            return "What do you want to look in?";
        }

        IHaveInventory container = null;

        if (text.Length == 3)
        {
            container = p;
        }
        else if (text.Length == 5)
        {
            container = FetchContainer(p, text[4]);
            if (container == null)
            {
                return $"I cannot find the {text[4]}";
            }
        }

        return LookAtIn(text[2], container);
    }

    private IHaveInventory FetchContainer(Player p, string containerId)
    {
        GameObject obj = p.Locate(containerId);
        return obj as IHaveInventory;
    }

    private string LookAtIn(string thingId, IHaveInventory container)
    {
        GameObject obj = container.Locate(thingId);
        if (obj != null)
        {
            return obj.FullDescription;
        }
        else
        {
            return $"I cannot find the {thingId} in the {container.Name}";
        }
    }
}
