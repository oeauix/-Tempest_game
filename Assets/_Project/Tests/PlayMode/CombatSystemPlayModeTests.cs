using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Tempest.Gameplay.Combat;

public class CombatSystemPlayModeTests
{
    private GameObject _combatObject;
    private CombatSystem _combatSystem;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        _combatObject = new GameObject("CombatSystem");
        _combatSystem = _combatObject.AddComponent<CombatSystem>();
        yield return null;
    }

    [UnityTest]
    public IEnumerator CombatSystem_CanPerformAttack()
    {
        _combatSystem.PerformAttack(1.5f);
        Assert.IsNotNull(_combatSystem);
        yield return null;
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(_combatObject);
    }
}