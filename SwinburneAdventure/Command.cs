namespace SwinburneAdventure;


public abstract class Command
{
    private List<string> _identifiers;

    public Command(string[] ids)
    {
        _identifiers = new List<string>(ids);
    }

    public List<string> Identifiers
    {
        get { return _identifiers; }
    }

    public bool AreYou(string id)
    {
        return _identifiers.Contains(id.ToLower());
    }

    public abstract string Execute(Player p, string[] text);
}