using NUnit.Framework;
using UnityEngine;
using Tempest.World;

public class WorldManagerTests
{
    private GameObject _worldGo;
    private WorldManager _worldManager;

    [SetUp]
    public void Setup()
    {
        _worldGo = new GameObject("WorldManager");
        _worldManager = _worldGo.AddComponent<WorldManager>();
    }

    [Test]
    public void WorldManager_Initializes_Correctly()
    {
        Assert.IsNotNull(_worldManager);
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(_worldGo);
    }
}