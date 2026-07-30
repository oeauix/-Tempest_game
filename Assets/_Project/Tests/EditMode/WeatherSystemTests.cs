using NUnit.Framework;
using UnityEngine;
using Tempest.World;

public class WeatherSystemTests
{
    private GameObject _weatherObject;
    private WeatherSystem _weatherSystem;

    [SetUp]
    public void Setup()
    {
        _weatherObject = new GameObject("WeatherSystem");
        _weatherSystem = _weatherObject.AddComponent<WeatherSystem>();
    }

    [Test]
    public void WeatherSystem_DefaultWeather_IsClear()
    {
        Assert.AreEqual(WeatherType.Clear, _weatherSystem.currentWeather);
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(_weatherObject);
    }
}