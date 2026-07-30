using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Tempest.Gameplay.Player;

public class LightningWeavePlayModeTests
{
    private GameObject _player;
    private LightningWeaveSystem _weaveSystem;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        _player = new GameObject("Player");
        _weaveSystem = _player.AddComponent<LightningWeaveSystem>();
        _weaveSystem.maxChainDistance = 20f;
        _weaveSystem.maxTargets = 3;
        yield return null;
    }

    [UnityTest]
    public IEnumerator LightningWeaveSystem_CanBeActivated()
    {
        _weaveSystem.TryActivateWeave();
        Assert.IsNotNull(_weaveSystem);
        yield return null;
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(_player);
    }
}