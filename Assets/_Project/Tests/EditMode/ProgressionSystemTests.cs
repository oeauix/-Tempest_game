using NUnit.Framework;
using UnityEngine;
using Tempest.Gameplay.Progression;

public class ProgressionSystemTests
{
    private GameObject _progressionObject;
    private ProgressionSystem _progressionSystem;

    [SetUp]
    public void Setup()
    {
        _progressionObject = new GameObject("ProgressionSystem");
        _progressionSystem = _progressionObject.AddComponent<ProgressionSystem>();
    }

    [Test]
    public void GainSkillPoints_IncreasesPoints()
    {
        _progressionSystem.GainSkillPoints(5);
        Assert.AreEqual(5, _progressionSystem.skillPoints);
    }

    [Test]
    public void UpgradeCore_RequiresEnoughPoints()
    {
        _progressionSystem.skillPoints = 2;
        int initialLevel = _progressionSystem.stormCoreLevel;
        _progressionSystem.UpgradeCore();
        Assert.AreEqual(initialLevel, _progressionSystem.stormCoreLevel);
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(_progressionObject);
    }
}