using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Tempest.Gameplay.Progression;
using Tempest.Gameplay.Faction;

public class ProgressionAndFactionIntegrationTest
{
    private GameObject _progressionGo;
    private ProgressionSystem _progressionSystem;
    private GameObject _factionGo;
    private FactionManager _factionManager;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        _progressionGo = new GameObject("Progression");
        _progressionSystem = _progressionGo.AddComponent<ProgressionSystem>();

        _factionGo = new GameObject("Faction");
        _factionManager = _factionGo.AddComponent<FactionManager>();
        yield return null;
    }

    [UnityTest]
    public IEnumerator ProgressionAndFaction_CanWorkTogether()
    {
        _progressionSystem.GainSkillPoints(9);
        _factionManager.ChangeReputation(FactionType.Gridkeepers, 50);
        Assert.IsNotNull(_progressionSystem);
        yield return null;
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(_progressionGo);
        Object.Destroy(_factionGo);
    }
}