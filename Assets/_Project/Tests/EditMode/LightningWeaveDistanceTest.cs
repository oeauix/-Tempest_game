using NUnit.Framework;
using UnityEngine;
using Tempest.Gameplay.Player;

public class LightningWeaveDistanceTest
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
    public void LightningWeave_GetMaxChainDistance_Works()
    {
        float dist = _weaveSystem.GetMaxChainDistance();
        Assert.Greater(dist, 0f);
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(_weaveGo);
    }
}