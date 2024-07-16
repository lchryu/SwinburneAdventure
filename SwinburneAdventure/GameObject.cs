namespace SwinburneAdventure;

public abstract class GameObject
{
    private List<string> _identifiers;
    private string _name;
    private string _description;

    public GameObject(string[] ids, string name, string desc)
    {
        _identifiers = new List<string>(ids);
        _name = name;
        _description = desc;
    }

    public string Name => _name;

    public string ShortDescription => $"{_name} ({FirstId})";

    public virtual string FullDescription => _description;

    public bool AreYou(string id)
    {
        return _identifiers.Contains(id.ToLower());
    }

    public string FirstId => _identifiers.Count > 0 ? _identifiers[0] : string.Empty;

    public void AddIdentifier(string id)
    {
        _identifiers.Add(id.ToLower());
    }
}
