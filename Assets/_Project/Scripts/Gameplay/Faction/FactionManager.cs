using UnityEngine;
using System.Collections.Generic;
using Tempest.Core;

namespace Tempest.Gameplay.Faction
{
    public enum FactionType { Forge, Veil, Awakened, Gridkeepers }

    public class FactionManager : MonoBehaviour
    {
        public Dictionary<FactionType, int> reputation = new Dictionary<FactionType, int>();

        private void Awake()
        {
            ServiceLocator.Register(this);
            InitializeReputation();
        }

        private void InitializeReputation()
        {
            foreach (FactionType faction in System.Enum.GetValues(typeof(FactionType)))
            {
                reputation[faction] = 0;
            }
        }

        public void ChangeReputation(FactionType faction, int amount)
        {
            reputation[faction] = Mathf.Clamp(reputation[faction] + amount, -100, 100);
            Debug.Log($"{faction} reputation changed by {amount}. New value: {reputation[faction]}");
        }
    }
}