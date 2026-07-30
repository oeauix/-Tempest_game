using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Tempest.Gameplay.Mission;

public class MissionManagerPlayModeTests
{
    private GameObject _missionGo;
    private MissionManager _missionManager;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        _missionGo = new GameObject("MissionManager");
        _missionManager = _missionGo.AddComponent<MissionManager>();
        yield return null;
    }

    [UnityTest]
    public IEnumerator MissionManager_CanCompleteMission()
    {
        _missionManager.StartMission("TestMission");
        _missionManager.CompleteMission();
        Assert.IsNotNull(_missionManager);
        yield return null;
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(_missionGo);
    }
}