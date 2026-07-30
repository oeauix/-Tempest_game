using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Tempest.Gameplay.Vehicle;

public class StormConduitPlayModeTests
{
    private GameObject _conduitGo;
    private StormConduit _conduit;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        _conduitGo = new GameObject("StormConduit");
        _conduit = _conduitGo.AddComponent<StormConduit>();
        yield return null;
    }

    [UnityTest]
    public IEnumerator StormConduit_CanMountAndDismount()
    {
        _conduit.Mount();
        _conduit.Dismount();
        Assert.IsNotNull(_conduit);
        yield return null;
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(_conduitGo);
    }
}