namespace SwinburneAdventure;

[TestFixture]
public class Test_MoveCommand
{
    private Player _player;
    private Location _startingLocation;
    private Location _destination;
    private Path _path;
    private MoveCommand _moveCommand;

    [SetUp]
    public void Setup()
    {
        _startingLocation = new Location("Starting Room", "A starting room.");
        _destination = new Location("Destination Room", "A destination room.");
        _path = new Path(new string[] { "north" }, _destination);
        _startingLocation.AddPath(_path);
        
        _player = new Player("Fred", "The mighty programmer");
        _player.CurrentLocation = _startingLocation;
        
        _moveCommand = new MoveCommand();
    }


    [Test]
    public void TestMoveNorth()
    {
        string result = _moveCommand.Execute(_player, new string[] { "move", "north" });
        Assert.AreEqual(_player.CurrentLocation, _destination);
        Assert.AreEqual(result, "You head north.\nA destination room.\nYou can see:\n");
        
        // debug
        Console.WriteLine($"actually = [{result}]");
        Console.WriteLine($"expected = [{"You head north.\nA destination room.\nYou can see:\n"}]");
    }

    [Test]
    public void TestMoveInvalidDirection()
    {
        string result = _moveCommand.Execute(_player, new string[] { "move", "south" });
        Assert.AreEqual(_player.CurrentLocation, _startingLocation);
        Assert.AreEqual(result, "There is no path to the south.");
    }

    [Test]
    public void TestInvalidMoveCommand()
    {
        string result = _moveCommand.Execute(_player, new string[] { "move" });
        Assert.AreEqual(result, "I don't know how to move like that.");
    }
}
