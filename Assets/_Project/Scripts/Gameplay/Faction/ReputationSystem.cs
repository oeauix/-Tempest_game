using UnityEngine;
using Tempest.Core;

namespace Tempest.Gameplay.Faction
{
    public class ReputationSystem : MonoBehaviour
    {
        private FactionManager _factionManager;

        private void Awake()
        {
            _factionManager = ServiceLocator.Resolve<FactionManager>();
            ServiceLocator.Register(this);
        }

        public int GetReputationLevel(FactionType faction)
        {
            int rep = _factionManager.reputation[faction];
            if (rep >= 75) return 5;
            if (rep >= 50) return 4;
            if (rep >= 25) return 3;
            if (rep >= 0) return 2;
            if (rep >= -50) return 1;
            return 0;
        }
    }
}