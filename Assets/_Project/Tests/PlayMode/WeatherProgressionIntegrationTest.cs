using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Tempest.World;
using Tempest.Gameplay.Progression;

public class WeatherProgressionIntegrationTest
{
    private GameObject _weatherGo;
    private WeatherSystem _weatherSystem;
    private GameObject _progressionGo;
    private ProgressionSystem _progressionSystem;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        _weatherGo = new GameObject("Weather");
        _weatherSystem = _weatherGo.AddComponent<WeatherSystem>();

        _progressionGo = new GameObject("Progression");
        _progressionSystem = _progressionGo.AddComponent<ProgressionSystem>();
        yield return null;
    }

    [UnityTest]
    public IEnumerator WeatherAndProgression_CanWorkTogether()
    {
        _weatherSystem.SetWeather(WeatherType.HeavyStorm);
        _progressionSystem.GainSkillPoints(5);
        Assert.IsNotNull(_progressionSystem);
        yield return null;
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(_weatherGo);
        Object.Destroy(_progressionGo);
    }
}