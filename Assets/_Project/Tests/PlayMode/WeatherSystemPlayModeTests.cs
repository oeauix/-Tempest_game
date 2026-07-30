using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Tempest.World;

public class WeatherSystemPlayModeTests
{
    private GameObject _weatherObject;
    private WeatherSystem _weatherSystem;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        _weatherObject = new GameObject("WeatherSystem");
        _weatherSystem = _weatherObject.AddComponent<WeatherSystem>();
        yield return null;
    }

    [UnityTest]
    public IEnumerator WeatherSystem_CanChangeWeather()
    {
        _weatherSystem.SetWeather(WeatherType.HeavyStorm);
        Assert.AreEqual(WeatherType.HeavyStorm, _weatherSystem.currentWeather);
        yield return null;
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(_weatherObject);
    }
}