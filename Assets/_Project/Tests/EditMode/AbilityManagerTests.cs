using NUnit.Framework;
using UnityEngine;
using Tempest.Gameplay.Combat;

public class AbilityManagerTests
{
    private GameObject _abilityObject;
    private AbilityManager _abilityManager;

    [SetUp]
    public void Setup()
    {
        _abilityObject = new GameObject("AbilityManager");
        _abilityManager = _abilityObject.AddComponent<AbilityManager>();
    }

    [Test]
    public void AbilityManager_CanActivateAbility()
    {
        _abilityManager.abilities.Add(new AbilityData { abilityName = "TestAbility" });
        _abilityManager.ActivateAbility(0);
        Assert.Pass();
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(_abilityObject);
    }
}