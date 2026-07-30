using UnityEngine;
using Tempest.Core;

namespace Tempest.Gameplay.Progression
{
    public class ProgressionSystem : MonoBehaviour
    {
        public int stormCoreLevel = 1;
        public int skillPoints = 0;

        private void Awake()
        {
            ServiceLocator.Register(this);
        }

        public void GainSkillPoints(int amount)
        {
            skillPoints += amount;
            Debug.Log($"Gained {amount} skill points. Total: {skillPoints}");
        }

        public void UpgradeCore()
        {
            if (skillPoints >= 3)
            {
                stormCoreLevel++;
                skillPoints -= 3;
                Debug.Log($"Storm Core upgraded to level {stormCoreLevel}");
            }
        }
    }
}