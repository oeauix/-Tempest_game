using NUnit.Framework;
using UnityEngine;
using Tempest.Gameplay.Player;

public class LightningWeaveAdvancedTests
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
    public void LightningWeave_MaxChainDistance_IsSet()
    {
        Assert.AreEqual(25f, _weaveSystem.maxChainDistance);
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(_weaveGo);
    }
}