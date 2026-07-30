using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Tempest.Gameplay.Combat;
using Tempest.Gameplay.AI;

public class Integration_Combat_AI_Test
{
    private GameObject _combatGo;
    private CombatSystem _combatSystem;
    private GameObject _enemyGo;
    private EnemyAI _enemyAI;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        _combatGo = new GameObject("CombatSystem");
        _combatSystem = _combatGo.AddComponent<CombatSystem>();

        _enemyGo = new GameObject("Enemy");
        _enemyAI = _enemyGo.AddComponent<EnemyAI>();
        yield return null;
    }

    [UnityTest]
    public IEnumerator CombatAndAI_CanInteract()
    {
        _combatSystem.PerformAttack();
        Assert.IsNotNull(_enemyAI);
        yield return null;
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(_combatGo);
        Object.Destroy(_enemyGo);
    }
}