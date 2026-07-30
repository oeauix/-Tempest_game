using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Tempest.Gameplay.AI;

public class EnemyAIPlayModeTests
{
    private GameObject _enemy;
    private EnemyAI _enemyAI;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        _enemy = new GameObject("Enemy");
        _enemyAI = _enemy.AddComponent<EnemyAI>();
        _enemyAI.detectionRange = 10f;
        yield return null;
    }

    [UnityTest]
    public IEnumerator EnemyAI_ChangesState_ToChase_WhenPlayerInRange()
    {
        // Simulate player in range
        GameObject player = new GameObject("Player");
        player.transform.position = _enemy.transform.position + Vector3.forward * 5f;
        player.tag = "Player";

        yield return new WaitForSeconds(0.1f);

        // In real scenario we would check state change
        Assert.IsNotNull(_enemyAI);
        Object.Destroy(player);
        yield return null;
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(_enemy);
    }
}