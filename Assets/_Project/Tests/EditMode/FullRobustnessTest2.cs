using NUnit.Framework;
using UnityEngine;
using Tempest.Core;
using Tempest.Gameplay.Combat;
using Tempest.Gameplay.Faction;
using Tempest.World;
using Tempest.Gameplay.Progression;
using Tempest.Gameplay.Vehicle;

public class FullRobustnessTest2
{
    [Test]
    public void AllSystems_Registered_WithoutError()
    {
        ServiceLocator.Clear();

        ServiceLocator.Register(new GameObject().AddComponent<CombatSystem>());
        ServiceLocator.Register(new GameObject().AddComponent<FactionManager>());
        ServiceLocator.Register(new GameObject().AddComponent<WeatherSystem>());
        ServiceLocator.Register(new GameObject().AddComponent<ProgressionSystem>());
        ServiceLocator.Register(new GameObject().AddComponent<StormConduit>());

        Assert.IsNotNull(ServiceLocator.Resolve<CombatSystem>());
        Assert.IsNotNull(ServiceLocator.Resolve<FactionManager>());
    }
}