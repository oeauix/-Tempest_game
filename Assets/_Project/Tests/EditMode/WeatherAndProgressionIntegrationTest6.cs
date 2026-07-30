using NUnit.Framework;
using UnityEngine;
using Tempest.World;
using Tempest.Gameplay.Progression;

public class WeatherAndProgressionIntegrationTest6
{
    private GameObject _weatherGo;
    private WeatherSystem _weatherSystem;
    private GameObject _progressionGo;
    private ProgressionSystem _progressionSystem;

    [SetUp]
    public void Setup()
    {
        _weatherGo = new GameObject("Weather");
        _weatherSystem = _weatherGo.AddComponent<WeatherSystem>();

        _progressionGo = new GameObject("Progression");
        _progressionSystem = _progressionGo.AddComponent<ProgressionSystem>();
    }

    [Test]
    public void WeatherAndProgression_CanCoexist6()
    {
        _weatherSystem.SetWeather(WeatherType.Clear);
        _progressionSystem.GainSkillPoints(8);
        Assert.IsNotNull(_progressionSystem);
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(_weatherGo);
        Object.DestroyImmediate(_progressionGo);
    }
}