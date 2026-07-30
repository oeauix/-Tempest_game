using NUnit.Framework;
using UnityEngine;
using Tempest.Core;
using Tempest.Gameplay.Combat;
using Tempest.Gameplay.Faction;
using Tempest.World;

public class FullCoreSystemsTest
{
    [Test]
    public void AllCoreSystems_CanBeRegistered()
    {
        ServiceLocator.Clear();

        var combat = new GameObject().AddComponent<CombatSystem>();
        var faction = new GameObject().AddComponent<FactionManager>();
        var weather = new GameObject().AddComponent<WeatherSystem>();

        ServiceLocator.Register(combat);
        ServiceLocator.Register(faction);
        ServiceLocator.Register(weather);

        Assert.IsNotNull(ServiceLocator.Resolve<CombatSystem>());
        Assert.IsNotNull(ServiceLocator.Resolve<FactionManager>());
        Assert.IsNotNull(ServiceLocator.Resolve<WeatherSystem>());
    }
}