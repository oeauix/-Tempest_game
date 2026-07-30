using UnityEngine;
using Tempest.Core;

namespace Tempest.UI
{
    public class TouchInputManager : MonoBehaviour
    {
        [Header("Touch Settings")]
        public float tapThreshold = 0.2f;

        private float _touchStartTime;

        private void Awake()
        {
            ServiceLocator.Register(this);
        }

        private void Update()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                    _touchStartTime = Time.time;

                if (touch.phase == TouchPhase.Ended)
                {
                    float duration = Time.time - _touchStartTime;
                    if (duration < tapThreshold)
                    {
                        // Tap detected - can trigger Lightning Strike
                        Debug.Log("Tap detected for Lightning Strike");
                    }
                }
            }
        }
    }
}