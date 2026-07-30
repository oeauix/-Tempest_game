using NUnit.Framework;
using Tempest.Gameplay.Faction;

public class FactionManagerTests
{
    private FactionManager _factionManager;

    [SetUp]
    public void Setup()
    {
        var go = new GameObject("FactionManager");
        _factionManager = go.AddComponent<FactionManager>();
    }

    [Test]
    public void FactionManager_Initializes_AllFactions()
    {
        Assert.AreEqual(4, _factionManager.reputation.Count);
    }

    [Test]
    public void ChangeReputation_UpdatesValue_Correctly()
    {
        _factionManager.ChangeReputation(FactionType.Forge, 25);
        Assert.AreEqual(25, _factionManager.reputation[FactionType.Forge]);
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(_factionManager.gameObject);
    }
}