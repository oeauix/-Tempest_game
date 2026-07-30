using NUnit.Framework;
using UnityEngine;
using Tempest.Gameplay.Player;

public class LightningWeaveNullSafetyTest
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
    public void LightningWeave_GetCurrentChainCount_SafeWithNull()
    {
        int count = _weaveSystem.GetCurrentChainCount();
        Assert.GreaterOrEqual(count, 0);
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(_weaveGo);
    }
}