using NUnit.Framework;
using UnityEngine;
using Tempest.Gameplay.Combat;
using Tempest.World;

public class CombatAndWeatherIntegrationTest
{
    private GameObject _combatGo;
    private CombatSystem _combatSystem;
    private GameObject _weatherGo;
    private WeatherSystem _weatherSystem;

    [SetUp]
    public void Setup()
    {
        _combatGo = new GameObject("Combat");
        _combatSystem = _combatGo.AddComponent<CombatSystem>();

        _weatherGo = new GameObject("Weather");
        _weatherSystem = _weatherGo.AddComponent<WeatherSystem>();
    }

    [Test]
    public void CombatAndWeather_CanCoexist()
    {
        _combatSystem.PerformAttack(1.2f);
        _weatherSystem.SetWeather(WeatherType.HeavyStorm);
        Assert.IsNotNull(_combatSystem);
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(_combatGo);
        Object.DestroyImmediate(_weatherGo);
    }
}