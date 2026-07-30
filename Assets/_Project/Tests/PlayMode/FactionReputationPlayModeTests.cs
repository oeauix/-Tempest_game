using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Tempest.Gameplay.Faction;

public class FactionReputationPlayModeTests
{
    private GameObject _factionGo;
    private FactionManager _factionManager;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        _factionGo = new GameObject("FactionManager");
        _factionManager = _factionGo.AddComponent<FactionManager>();
        yield return null;
    }

    [UnityTest]
    public IEnumerator Reputation_CanBeChanged_Dynamically()
    {
        _factionManager.ChangeReputation(FactionType.Awakened, 40);
        Assert.AreEqual(40, _factionManager.reputation[FactionType.Awakened]);
        yield return null;
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(_factionGo);
    }
}