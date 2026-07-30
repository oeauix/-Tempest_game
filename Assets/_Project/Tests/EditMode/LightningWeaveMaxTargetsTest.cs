using NUnit.Framework;
using UnityEngine;
using Tempest.Gameplay.Player;

public class LightningWeaveMaxTargetsTest
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
    public void LightningWeave_GetMaxTargets_Works()
    {
        int targets = _weaveSystem.GetMaxTargets();
        Assert.Greater(targets, 0);
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(_weaveGo);
    }
}