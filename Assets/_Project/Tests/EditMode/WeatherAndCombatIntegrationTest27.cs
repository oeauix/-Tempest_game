using NUnit.Framework;
using UnityEngine;
using Tempest.World;
using Tempest.Gameplay.Combat;

public class WeatherAndCombatIntegrationTest27
{
    private GameObject _weatherGo;
    private WeatherSystem _weatherSystem;
    private GameObject _combatGo;
    private CombatSystem _combatSystem;

    [SetUp]
    public void Setup()
    {
        _weatherGo = new GameObject("Weather");
        _weatherSystem = _weatherGo.AddComponent<WeatherSystem>();

        _combatGo = new GameObject("Combat");
        _combatSystem = _combatGo.AddComponent<CombatSystem>();
    }

    [Test]
    public void WeatherAndCombat_CanCoexist27()
    {
        _weatherSystem.SetWeather(WeatherType.LightningStorm);
        _combatSystem.PerformAttack(1.8f);
        Assert.IsNotNull(_combatSystem);
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(_weatherGo);
        Object.DestroyImmediate(_combatGo);
    }
}