namespace SwinburneAdventure;
public class IdentifiableObject
{
    private List<string> _identifiers;

    public IdentifiableObject(string[] identifiers)
    {
        _identifiers = new(identifiers);
    }
    
    public bool AreYou(string id)
    {
        return _identifiers.Contains(id.ToLower());
    }
    public void AddIdentifier(string id)
    {
        _identifiers.Add(id.ToLower());
    }

    public string? FirstId
    {
        get
        {
            return _identifiers.Count > 0 ? _identifiers[0] : string.Empty;
        }
    }
}