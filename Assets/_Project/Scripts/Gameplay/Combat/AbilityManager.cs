using UnityEngine;
using System.Collections.Generic;
using Tempest.Core;

namespace Tempest.Gameplay.Combat
{
    public class AbilityManager : MonoBehaviour
    {
        public List<AbilityData> abilities = new List<AbilityData>();

        private void Awake()
        {
            ServiceLocator.Register(this);
        }

        public void ActivateAbility(int index)
        {
            if (index < 0 || index >= abilities.Count) return;

            AbilityData ability = abilities[index];
            Debug.Log($"Activated ability: {ability.abilityName}");
            // TODO: Apply ability effects
        }
    }

    [System.Serializable]
    public class AbilityData
    {
        public string abilityName;
        public float cooldown;
        public float energyCost;
    }
}