using NUnit.Framework;
using UnityEngine;
using Tempest.World;
using Tempest.Gameplay.Faction;

public class WeatherAndFactionIntegrationTest20
{
    private GameObject _weatherGo;
    private WeatherSystem _weatherSystem;
    private GameObject _factionGo;
    private FactionManager _factionManager;

    [SetUp]
    public void Setup()
    {
        _weatherGo = new GameObject("Weather");
        _weatherSystem = _weatherGo.AddComponent<WeatherSystem>();

        _factionGo = new GameObject("Faction");
        _factionManager = _factionGo.AddComponent<FactionManager>();
    }

    [Test]
    public void WeatherAndFaction_CanCoexist20()
    {
        _weatherSystem.SetWeather(WeatherType.LightRain);
        _factionManager.ChangeReputation(FactionType.Gridkeepers, 7);
        Assert.IsNotNull(_factionManager);
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(_weatherGo);
        Object.DestroyImmediate(_factionGo);
    }
}