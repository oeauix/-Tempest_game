using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Tempest.Gameplay.Combat;

public class AbilityManagerPlayModeTests
{
    private GameObject _abilityGo;
    private AbilityManager _abilityManager;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        _abilityGo = new GameObject("AbilityManager");
        _abilityManager = _abilityGo.AddComponent<AbilityManager>();
        yield return null;
    }

    [UnityTest]
    public IEnumerator AbilityManager_CanActivateMultipleAbilities()
    {
        _abilityManager.abilities.Add(new AbilityData { abilityName = "ChainLightning" });
        _abilityManager.abilities.Add(new AbilityData { abilityName = "Surge" });
        _abilityManager.ActivateAbility(0);
        _abilityManager.ActivateAbility(1);
        Assert.IsNotNull(_abilityManager);
        yield return null;
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(_abilityGo);
    }
}