using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Tempest.World;

public class WorldManagerPlayModeTests
{
    private GameObject _worldGo;
    private WorldManager _worldManager;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        _worldGo = new GameObject("WorldManager");
        _worldManager = _worldGo.AddComponent<WorldManager>();
        yield return null;
    }

    [UnityTest]
    public IEnumerator WorldManager_CanLoadDistrict()
    {
        _worldManager.LoadDistrict(0);
        Assert.IsNotNull(_worldManager);
        yield return null;
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(_worldGo);
    }
}