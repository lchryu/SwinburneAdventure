namespace SwinburneAdventure;

using System;

public class MoveCommand : Command
{
    public MoveCommand() : base(new string[] { "move", "go", "head", "leave" })
    {
    }

    public override string Execute(Player p, string[] text)
    {
        if (text.Length != 2)
        {
            return "I don't know how to move like that.";
        }

        string direction = text[1].ToLower();
        Path path = p.CurrentLocation.GetPath(direction);

        if (path == null)
        {
            return $"There is no path to the {direction}.";
        }

        p.CurrentLocation = path.Destination;
        return $"You head {direction}.\n{p.CurrentLocation.FullDescription}";
    }
}
