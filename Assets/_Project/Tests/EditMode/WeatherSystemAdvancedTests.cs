using NUnit.Framework;
using UnityEngine;
using Tempest.World;

public class WeatherSystemAdvancedTests
{
    private GameObject _weatherGo;
    private WeatherSystem _weatherSystem;

    [SetUp]
    public void Setup()
    {
        _weatherGo = new GameObject("WeatherSystem");
        _weatherSystem = _weatherGo.AddComponent<WeatherSystem>();
    }

    [Test]
    public void WeatherSystem_CanSetMultipleWeathers()
    {
        _weatherSystem.SetWeather(WeatherType.LightningStorm);
        _weatherSystem.SetWeather(WeatherType.LightRain);
        Assert.AreEqual(WeatherType.LightRain, _weatherSystem.currentWeather);
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(_weatherGo);
    }
}