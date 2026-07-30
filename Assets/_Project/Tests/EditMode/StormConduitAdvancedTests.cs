using NUnit.Framework;
using UnityEngine;
using Tempest.Gameplay.Vehicle;

public class StormConduitAdvancedTests
{
    private GameObject _conduitGo;
    private StormConduit _conduit;

    [SetUp]
    public void Setup()
    {
        _conduitGo = new GameObject("StormConduit");
        _conduit = _conduitGo.AddComponent<StormConduit>();
        _conduit.maxSpeed = 50f;
    }

    [Test]
    public void StormConduit_MaxSpeed_IsCorrect()
    {
        Assert.AreEqual(50f, _conduit.maxSpeed);
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(_conduitGo);
    }
}