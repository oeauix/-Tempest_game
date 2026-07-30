using NUnit.Framework;
using UnityEngine;
using Tempest.Core;
using Tempest.Gameplay.Combat;
using Tempest.Gameplay.Faction;
using Tempest.World;
using Tempest.Gameplay.Progression;

public class FullSystemRobustnessTest
{
    [Test]
    public void AllMajorSystems_CanWorkTogether()
    {
        ServiceLocator.Clear();

        var combat = new GameObject().AddComponent<CombatSystem>();
        var faction = new GameObject().AddComponent<FactionManager>();
        var weather = new GameObject().AddComponent<WeatherSystem>();
        var progression = new GameObject().AddComponent<ProgressionSystem>();

        ServiceLocator.Register(combat);
        ServiceLocator.Register(faction);
        ServiceLocator.Register(weather);
        ServiceLocator.Register(progression);

        Assert.IsNotNull(ServiceLocator.Resolve<CombatSystem>());
        Assert.IsNotNull(ServiceLocator.Resolve<FactionManager>());
        Assert.IsNotNull(ServiceLocator.Resolve<WeatherSystem>());
        Assert.IsNotNull(ServiceLocator.Resolve<ProgressionSystem>());
    }
}