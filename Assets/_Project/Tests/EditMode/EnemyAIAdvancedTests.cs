using NUnit.Framework;
using UnityEngine;
using Tempest.Gameplay.AI;

public class EnemyAIAdvancedTests
{
    private GameObject _enemyGo;
    private EnemyAI _enemyAI;

    [SetUp]
    public void Setup()
    {
        _enemyGo = new GameObject("Enemy");
        _enemyAI = _enemyGo.AddComponent<EnemyAI>();
        _enemyAI.attackRange = 4f;
    }

    [Test]
    public void EnemyAI_AttackRange_IsSet()
    {
        Assert.AreEqual(4f, _enemyAI.attackRange);
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(_enemyGo);
    }
}