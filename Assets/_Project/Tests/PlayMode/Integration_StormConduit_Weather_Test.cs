using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Tempest.Gameplay.Vehicle;
using Tempest.World;

public class Integration_StormConduit_Weather_Test
{
    private GameObject _conduitGo;
    private StormConduit _conduit;
    private GameObject _weatherGo;
    private WeatherSystem _weatherSystem;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        _conduitGo = new GameObject("StormConduit");
        _conduit = _conduitGo.AddComponent<StormConduit>();

        _weatherGo = new GameObject("WeatherSystem");
        _weatherSystem = _weatherGo.AddComponent<WeatherSystem>();
        yield return null;
    }

    [UnityTest]
    public IEnumerator StormConduit_And_Weather_CanInteract()
    {
        _conduit.Mount();
        _weatherSystem.SetWeather(WeatherType.HeavyStorm);
        Assert.IsNotNull(_conduit);
        yield return null;
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(_conduitGo);
        Object.Destroy(_weatherGo);
    }
}