using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Tempest.Gameplay.Faction;
using Tempest.Gameplay.Mission;

public class Integration_Faction_Mission_Test
{
    private GameObject _factionGo;
    private FactionManager _factionManager;
    private GameObject _missionGo;
    private MissionManager _missionManager;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        _factionGo = new GameObject("FactionManager");
        _factionManager = _factionGo.AddComponent<FactionManager>();

        _missionGo = new GameObject("MissionManager");
        _missionManager = _missionGo.AddComponent<MissionManager>();
        yield return null;
    }

    [UnityTest]
    public IEnumerator FactionAndMission_CanInteract()
    {
        _factionManager.ChangeReputation(FactionType.Forge, 30);
        _missionManager.StartMission("FactionMission");
        Assert.IsNotNull(_missionManager);
        yield return null;
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(_factionGo);
        Object.Destroy(_missionGo);
    }
}