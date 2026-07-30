using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using Tempest.Core;

namespace Tempest.VFX
{
    public class PostProcessingController : MonoBehaviour
    {
        public Volume globalVolume;

        private void Awake()
        {
            ServiceLocator.Register(this);
        }

        public void SetStormIntensity(float intensity)
        {
            if (globalVolume == null) return;

            if (globalVolume.profile.TryGet(out Bloom bloom))
            {
                bloom.intensity.value = Mathf.Lerp(1f, 3.5f, intensity);
            }
        }
    }
}