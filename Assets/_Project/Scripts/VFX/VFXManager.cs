using UnityEngine;
using Tempest.Core;

namespace Tempest.VFX
{
    public class VFXManager : MonoBehaviour
    {
        public static VFXManager Instance { get; private set; }

        [Header("Lightning Effects")]
        public GameObject lightningBoltPrefab;
        public GameObject impactEffectPrefab;

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

        public void PlayLightningBolt(Vector3 start, Vector3 end)
        {
            if (lightningBoltPrefab == null) return;

            GameObject bolt = Instantiate(lightningBoltPrefab, start, Quaternion.identity);
            // In real project: use LineRenderer or VFX Graph
            Destroy(bolt, 0.7f);
        }

        public void PlayImpactEffect(Vector3 position)
        {
            if (impactEffectPrefab != null)
            {
                Instantiate(impactEffectPrefab, position, Quaternion.identity);
            }
        }
    }
}