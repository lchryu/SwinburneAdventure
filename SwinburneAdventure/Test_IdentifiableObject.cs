namespace SwinburneAdventure;

using NUnit.Framework;

[TestFixture]
public class Test_IdentifiableObject
{
    private IdentifiableObject _idObject;

    [SetUp]
    public void Setup()
    {
        _idObject = new IdentifiableObject(new string[] { "fred", "bob" });
    }

    [Test]
    public void TestAreYou()
    {
        Assert.IsTrue(_idObject.AreYou("fred"));
        Assert.IsTrue(_idObject.AreYou("bob"));
    }

    [Test]
    public void TestNotAreYou()
    {
        Assert.IsFalse(_idObject.AreYou("wilma"));
        Assert.IsFalse(_idObject.AreYou("boby"));
    }

    [Test]
    public void TestCaseSensitive()
    {
        Assert.IsTrue(_idObject.AreYou("FRED"));
        Assert.IsTrue(_idObject.AreYou("bOB"));
    }

    [Test]
    public void TestFirstId()
    {
        Assert.AreEqual("fred", _idObject.FirstId);
    }

    [Test]
    public void TestFirstIdWithNoIds()
    {
        IdentifiableObject emptyIdObject = new IdentifiableObject(new string[] { });
        Assert.AreEqual(string.Empty, emptyIdObject.FirstId);
    }

    [Test]
    public void TestAddId()
    {
        _idObject.AddIdentifier("wilma");
        Assert.IsTrue(_idObject.AreYou("fred"));
        Assert.IsTrue(_idObject.AreYou("bob"));
        Assert.IsTrue(_idObject.AreYou("wilma"));
    }
}
