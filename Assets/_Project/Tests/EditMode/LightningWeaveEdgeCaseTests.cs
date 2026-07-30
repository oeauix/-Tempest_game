using NUnit.Framework;
using UnityEngine;
using Tempest.Gameplay.Player;

public class LightningWeaveEdgeCaseTests
{
    private GameObject _weaveGo;
    private LightningWeaveSystem _weaveSystem;

    [SetUp]
    public void Setup()
    {
        _weaveGo = new GameObject("LightningWeave");
        _weaveSystem = _weaveGo.AddComponent<LightningWeaveSystem>();
    }

    [Test]
    public void LightningWeave_MaxTargets_IsSet()
    {
        Assert.AreEqual(5, _weaveSystem.maxTargets);
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(_weaveGo);
    }
}