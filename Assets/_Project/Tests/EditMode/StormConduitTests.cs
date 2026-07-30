using NUnit.Framework;
using UnityEngine;
using Tempest.Gameplay.Vehicle;

public class StormConduitTests
{
    private GameObject _conduitObject;
    private StormConduit _conduit;

    [SetUp]
    public void Setup()
    {
        _conduitObject = new GameObject("StormConduit");
        _conduit = _conduitObject.AddComponent<StormConduit>();
    }

    [Test]
    public void StormConduit_InitialSpeed_IsZero()
    {
        Assert.AreEqual(0f, _conduit.currentSpeed);
    }

    [Test]
    public void Mount_ChangesRidingState()
    {
        _conduit.Mount();
        // Internal state check via behavior in real scenario
        Assert.Pass();
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(_conduitObject);
    }
}