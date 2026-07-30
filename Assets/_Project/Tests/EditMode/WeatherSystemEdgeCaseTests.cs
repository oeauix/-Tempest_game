using NUnit.Framework;
using UnityEngine;
using Tempest.World;

public class WeatherSystemEdgeCaseTests
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
    public void WeatherSystem_Default_IsClear()
    {
        Assert.AreEqual(WeatherType.Clear, _weatherSystem.currentWeather);
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(_weatherGo);
    }
}