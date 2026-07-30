using NUnit.Framework;
using UnityEngine;
using Tempest.Gameplay.Mission;

public class MissionManagerTests
{
    private GameObject _missionGo;
    private MissionManager _missionManager;

    [SetUp]
    public void Setup()
    {
        _missionGo = new GameObject("MissionManager");
        _missionManager = _missionGo.AddComponent<MissionManager>();
    }

    [Test]
    public void MissionManager_CanStartMission()
    {
        _missionManager.StartMission("TestMission_01");
        Assert.Pass();
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(_missionGo);
    }
}