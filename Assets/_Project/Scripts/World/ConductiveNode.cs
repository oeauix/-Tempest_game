using UnityEngine;

namespace Tempest.World
{
    public class ConductiveNode : MonoBehaviour
    {
        [Header("Node Settings")]
        public float energyStored = 100f;
        public bool isActive = true;

        public void ActivateNode()
        {
            if (!isActive) return;
            isActive = false;
            Debug.Log($"[World] Conductive Node {gameObject.name} activated!");
            // Trigger lightning effects and energy release
        }

        public void ResetNode()
        {
            isActive = true;
        }
    }
}