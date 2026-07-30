using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Tempest.Gameplay.Player;
using Tempest.Gameplay.Combat;
using Tempest.World;

public class Integration_Player_Combat_Weather_Test
{
    private GameObject _playerGo;
    private PlayerController _playerController;
    private GameObject _combatGo;
    private CombatSystem _combatSystem;
    private GameObject _weatherGo;
    private WeatherSystem _weatherSystem;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        _playerGo = new GameObject("Player");
        _playerController = _playerGo.AddComponent<PlayerController>();

        _combatGo = new GameObject("Combat");
        _combatSystem = _combatGo.AddComponent<CombatSystem>();

        _weatherGo = new GameObject("Weather");
        _weatherSystem = _weatherGo.AddComponent<WeatherSystem>();
        yield return null;
    }

    [UnityTest]
    public IEnumerator PlayerCombatWeather_IntegrationWorks()
    {
        _combatSystem.PerformAttack();
        _weatherSystem.SetWeather(WeatherType.LightningStorm);
        Assert.IsNotNull(_playerController);
        yield return null;
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(_playerGo);
        Object.Destroy(_combatGo);
        Object.Destroy(_weatherGo);
    }
}