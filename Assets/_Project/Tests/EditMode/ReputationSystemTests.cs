using NUnit.Framework;
using UnityEngine;
using Tempest.Gameplay.Faction;

public class ReputationSystemTests
{
    private GameObject _repObject;
    private ReputationSystem _repSystem;
    private FactionManager _factionManager;

    [SetUp]
    public void Setup()
    {
        var factionGo = new GameObject("FactionManager");
        _factionManager = factionGo.AddComponent<FactionManager>();

        _repObject = new GameObject("ReputationSystem");
        _repSystem = _repObject.AddComponent<ReputationSystem>();
    }

    [Test]
    public void GetReputationLevel_ReturnsCorrectLevel()
    {
        _factionManager.ChangeReputation(FactionType.Veil, 80);
        int level = _repSystem.GetReputationLevel(FactionType.Veil);
        Assert.AreEqual(5, level);
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(_repObject);
        Object.DestroyImmediate(_factionManager.gameObject);
    }
}