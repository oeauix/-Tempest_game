using UnityEngine;
using Tempest.Core;

namespace Tempest.Gameplay.Vehicle
{
    public class StormConduit : MonoBehaviour
    {
        [Header("Conduit Stats")]
        public float maxSpeed = 45f;
        public float acceleration = 12f;
        public float currentSpeed;

        private bool _isRiding;

        private void Awake()
        {
            ServiceLocator.Register(this);
        }

        public void Mount()
        {
            _isRiding = true;
            Debug.Log("Player mounted Storm Conduit");
        }

        public void Dismount()
        {
            _isRiding = false;
            Debug.Log("Player dismounted Storm Conduit");
        }

        public void UpdateMovement(float input)
        {
            if (!_isRiding) return;
            currentSpeed = Mathf.Lerp(currentSpeed, maxSpeed * input, Time.deltaTime * acceleration);
        }
    }
}