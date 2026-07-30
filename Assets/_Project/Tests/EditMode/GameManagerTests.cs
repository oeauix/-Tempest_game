using NUnit.Framework;
using UnityEngine;
using Tempest.Core;

public class GameManagerTests
{
    private GameObject _gmGo;
    private GameManager _gameManager;

    [SetUp]
    public void Setup()
    {
        _gmGo = new GameObject("GameManager");
        _gameManager = _gmGo.AddComponent<GameManager>();
    }

    [Test]
    public void GameManager_Initializes_Correctly()
    {
        Assert.IsNotNull(_gameManager);
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(_gmGo);
    }
}