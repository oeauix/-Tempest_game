using NUnit.Framework;
using UnityEngine;
using Tempest.Gameplay.Player;

public class PlayerControllerSpeedTest
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
    public void PlayerController_HasSpeedMethod()
    {
        float speed = _playerController.GetCurrentSpeed();
        Assert.GreaterOrEqual(speed, 0f);
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(_playerGo);
    }
}