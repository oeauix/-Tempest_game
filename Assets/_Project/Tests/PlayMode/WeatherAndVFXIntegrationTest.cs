using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Tempest.World;
using Tempest.VFX;

public class WeatherAndVFXIntegrationTest
{
    private GameObject _weatherGo;
    private WeatherSystem _weatherSystem;
    private GameObject _vfxGo;
    private VFXManager _vfxManager;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        _weatherGo = new GameObject("WeatherSystem");
        _weatherSystem = _weatherGo.AddComponent<WeatherSystem>();

        _vfxGo = new GameObject("VFXManager");
        _vfxManager = _vfxGo.AddComponent<VFXManager>();
        yield return null;
    }

    [UnityTest]
    public IEnumerator WeatherAndVFX_CanWorkTogether()
    {
        _weatherSystem.SetWeather(WeatherType.LightningStorm);
        _vfxManager.PlayLightningBolt(Vector3.zero, Vector3.up);
        Assert.IsNotNull(_vfxManager);
        yield return null;
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(_weatherGo);
        Object.Destroy(_vfxGo);
    }
}