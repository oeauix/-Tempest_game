using NUnit.Framework;
using UnityEngine;
using Tempest.Gameplay.Player;

public class LightningWeaveSystemTests
{
    private GameObject _weaveObject;
    private LightningWeaveSystem _weaveSystem;

    [SetUp]
    public void Setup()
    {
        _weaveObject = new GameObject("WeaveSystem");
        _weaveSystem = _weaveObject.AddComponent<LightningWeaveSystem>();
    }

    [Test]
    public void WeaveSystem_Initializes_Correctly()
    {
        Assert.IsNotNull(_weaveSystem);
        Assert.AreEqual(25f, _weaveSystem.maxChainDistance);
        Assert.AreEqual(5, _weaveSystem.maxTargets);
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(_weaveObject);
    }
}