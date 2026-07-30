using NUnit.Framework;
using UnityEngine;
using Tempest.Gameplay.Combat;

public class CombatSystemAdvancedTests
{
    private GameObject _combatGo;
    private CombatSystem _combatSystem;

    [SetUp]
    public void Setup()
    {
        _combatGo = new GameObject("Combat");
        _combatSystem = _combatGo.AddComponent<CombatSystem>();
    }

    [Test]
    public void CombatSystem_ComboWindow_IsSet()
    {
        Assert.AreEqual(1.2f, _combatSystem.comboWindow);
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(_combatGo);
    }
}