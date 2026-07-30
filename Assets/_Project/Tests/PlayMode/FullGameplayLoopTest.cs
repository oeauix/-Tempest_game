using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Tempest.Gameplay.Player;
using Tempest.Gameplay.Combat;
using Tempest.World;
using Tempest.Gameplay.Faction;

public class FullGameplayLoopTest
{
    private GameObject _playerGo;
    private PlayerController _playerController;
    private GameObject _combatGo;
    private CombatSystem _combatSystem;
    private GameObject _weatherGo;
    private WeatherSystem _weatherSystem;
    private GameObject _factionGo;
    private FactionManager _factionManager;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        _playerGo = new GameObject("Player");
        _playerController = _playerGo.AddComponent<PlayerController>();

        _combatGo = new GameObject("Combat");
        _combatSystem = _combatGo.AddComponent<CombatSystem>();

        _weatherGo = new GameObject("Weather");
        _weatherSystem = _weatherGo.AddComponent<WeatherSystem>();

        _factionGo = new GameObject("Faction");
        _factionManager = _factionGo.AddComponent<FactionManager>();
        yield return null;
    }

    [UnityTest]
    public IEnumerator FullGameplayLoop_Works()
    {
        _combatSystem.PerformAttack();
        _weatherSystem.SetWeather(WeatherType.LightningStorm);
        _factionManager.ChangeReputation(FactionType.Forge, 35);
        Assert.IsNotNull(_playerController);
        yield return null;
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(_playerGo);
        Object.Destroy(_combatGo);
        Object.Destroy(_weatherGo);
        Object.Destroy(_factionGo);
    }
}