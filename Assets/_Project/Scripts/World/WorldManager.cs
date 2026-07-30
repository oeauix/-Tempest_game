using UnityEngine;
using Tempest.Core;

namespace Tempest.World
{
    public class WorldManager : MonoBehaviour
    {
        public static WorldManager Instance { get; private set; }

        [Header("Districts")]
        public DistrictData[] districts;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            ServiceLocator.Register(this);
        }

        public void LoadDistrict(int index)
        {
            if (index < 0 || index >= districts.Length) return;
            Debug.Log($"Loading District: {districts[index].districtName}");
            // Addressables loading logic will be added here
        }
    }

    [System.Serializable]
    public class DistrictData
    {
        public string districtName;
        public GameObject districtPrefab;
        public WeatherType defaultWeather;
    }

    public enum WeatherType
    {
        Clear,
        LightRain,
        HeavyStorm,
        LightningStorm
    }
}