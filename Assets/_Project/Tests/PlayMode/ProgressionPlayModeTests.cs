using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Tempest.Gameplay.Progression;

public class ProgressionPlayModeTests
{
    private GameObject _progressionGo;
    private ProgressionSystem _progressionSystem;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        _progressionGo = new GameObject("ProgressionSystem");
        _progressionSystem = _progressionGo.AddComponent<ProgressionSystem>();
        yield return null;
    }

    [UnityTest]
    public IEnumerator ProgressionSystem_CanGainAndSpendPoints()
    {
        _progressionSystem.GainSkillPoints(6);
        _progressionSystem.UpgradeCore();
        Assert.AreEqual(3, _progressionSystem.skillPoints);
        yield return null;
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(_progressionGo);
    }
}