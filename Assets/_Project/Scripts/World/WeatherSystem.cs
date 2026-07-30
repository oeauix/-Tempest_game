using UnityEngine;
using Tempest.Core;

namespace Tempest.World
{
    public class WeatherSystem : MonoBehaviour
    {
        public WeatherType currentWeather { get; private set; } = WeatherType.Clear;

        [Header("Weather Settings")]
        public ParticleSystem rainParticle;
        public Light stormLight;

        private void Awake()
        {
            ServiceLocator.Register(this);
        }

        public void SetWeather(WeatherType newWeather)
        {
            currentWeather = newWeather;
            Debug.Log($"Weather changed to: {newWeather}");

            if (rainParticle != null)
            {
                if (newWeather == WeatherType.HeavyStorm || newWeather == WeatherType.LightningStorm)
                    rainParticle.Play();
                else
                    rainParticle.Stop();
            }
        }
    }
}