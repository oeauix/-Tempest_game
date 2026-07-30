using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Tempest.Gameplay.Player;

public class PlayerControllerPlayModeTests
{
    private GameObject _playerObject;
    private PlayerController _playerController;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        _playerObject = new GameObject("TestPlayer");
        _playerController = _playerObject.AddComponent<PlayerController>();
        yield return null;
    }

    [UnityTest]
    public IEnumerator PlayerController_Initializes_WithoutError()
    {
        Assert.IsNotNull(_playerController);
        yield return null;
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(_playerObject);
    }
}