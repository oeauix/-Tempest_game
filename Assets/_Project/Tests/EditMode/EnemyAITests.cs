using NUnit.Framework;
using UnityEngine;
using Tempest.Gameplay.AI;

public class EnemyAITests
{
    private GameObject _enemyObject;
    private EnemyAI _enemyAI;

    [SetUp]
    public void Setup()
    {
        _enemyObject = new GameObject("Enemy");
        _enemyAI = _enemyObject.AddComponent<EnemyAI>();
    }

    [Test]
    public void EnemyAI_InitialState_IsIdle()
    {
        Assert.AreEqual(EnemyState.Idle, _enemyAI.currentState);
    }

    [Test]
    public void EnemyAI_DetectionRange_IsSet()
    {
        Assert.Greater(_enemyAI.detectionRange, 0f);
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(_enemyObject);
    }
}