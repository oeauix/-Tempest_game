using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Tempest.Core;
using Tempest.Gameplay.Combat;
using Tempest.Gameplay.Player;

public class FullIntegrationTest
{
    private GameObject _player;
    private PlayerController _playerController;
    private CombatSystem _combatSystem;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        ServiceLocator.Clear();

        _player = new GameObject("Player");
        _playerController = _player.AddComponent<PlayerController>();

        var combatGo = new GameObject("Combat");
        _combatSystem = combatGo.AddComponent<CombatSystem>();

        ServiceLocator.Register(_combatSystem);
        yield return null;
    }

    [UnityTest]
    public IEnumerator FullSystem_PlayerAndCombat_Integration()
    {
        _combatSystem.PerformAttack(2f);
        Assert.IsNotNull(_playerController);
        yield return null;
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(_player);
        ServiceLocator.Clear();
    }
}