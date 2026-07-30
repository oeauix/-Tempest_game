using NUnit.Framework;
using UnityEngine;
using Tempest.Gameplay.Player;

public class LightningWeaveForceTest
{
    private GameObject _weaveGo;
    private LightningWeaveSystem _weaveSystem;
    private GameObject _target;

    [SetUp]
    public void Setup()
    {
        _weaveGo = new GameObject("LightningWeave");
        _weaveSystem = _weaveGo.AddComponent<LightningWeaveSystem>();

        _target = new GameObject("Target");
    }

    [Test]
    public void LightningWeave_CanForceActivate()
    {
        _weaveSystem.ForceActivateWeave(_target.transform);
        Assert.Pass();
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(_weaveGo);
        Object.DestroyImmediate(_target);
    }
}