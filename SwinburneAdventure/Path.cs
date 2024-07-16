namespace SwinburneAdventure;

public class Path : IdentifiableObject
{
    public Location Destination { get; private set; }

    public Path(string[] ids, Location destination) : base(ids)
    {
        Destination = destination;
    }
}
