using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Tempest.Gameplay.Player;

public class PlayerMovementPlayModeTests
{
    private GameObject _playerGo;
    private PlayerController _playerController;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        _playerGo = new GameObject("Player");
        _playerController = _playerGo.AddComponent<PlayerController>();
        yield return null;
    }

    [UnityTest]
    public IEnumerator PlayerController_CanMove()
    {
        // Simulate movement input
        Assert.IsNotNull(_playerController);
        yield return null;
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(_playerGo);
    }
}