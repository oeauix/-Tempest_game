using NUnit.Framework;
using UnityEngine;
using Tempest.Core;
using Tempest.Gameplay.Combat;
using Tempest.Gameplay.Faction;

public class Integration_FullSystem_Test
{
    [Test]
    public void CoreSystems_CanBeRegistered_And_Resolved()
    {
        ServiceLocator.Clear();

        var combat = new GameObject("Combat").AddComponent<CombatSystem>();
        var faction = new GameObject("Faction").AddComponent<FactionManager>();

        ServiceLocator.Register(combat);
        ServiceLocator.Register(faction);

        var resolvedCombat = ServiceLocator.Resolve<CombatSystem>();
        var resolvedFaction = ServiceLocator.Resolve<FactionManager>();

        Assert.IsNotNull(resolvedCombat);
        Assert.IsNotNull(resolvedFaction);
    }
}