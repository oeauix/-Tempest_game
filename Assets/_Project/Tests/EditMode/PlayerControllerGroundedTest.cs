using NUnit.Framework;
using UnityEngine;
using Tempest.Gameplay.Player;

public class PlayerControllerGroundedTest
{
    private GameObject _playerGo;
    private PlayerController _playerController;

    [SetUp]
    public void Setup()
    {
        _playerGo = new GameObject("Player");
        _playerController = _playerGo.AddComponent<PlayerController>();
    }

    [Test]
    public void PlayerController_HasIsGroundedMethod()
    {
        Assert.IsNotNull(_playerController);
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(_playerGo);
    }
}