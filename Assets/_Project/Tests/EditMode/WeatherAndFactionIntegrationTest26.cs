using NUnit.Framework;
using UnityEngine;
using Tempest.World;
using Tempest.Gameplay.Faction;

public class WeatherAndFactionIntegrationTest26
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
    public void WeatherAndFaction_CanCoexist26()
    {
        _weatherSystem.SetWeather(WeatherType.LightningStorm);
        _factionManager.ChangeReputation(FactionType.Veil, 7);
        Assert.IsNotNull(_factionManager);
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(_weatherGo);
        Object.DestroyImmediate(_factionGo);
    }
}