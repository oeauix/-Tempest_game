using UnityEngine;
using System.Collections.Generic;
using Tempest.Core;

namespace Tempest.Gameplay.Player
{
    public class LightningWeaveSystem : MonoBehaviour
    {
        [Header("Weave Settings")]
        public float maxChainDistance = 25f;
        public int maxTargets = 5;
        public LayerMask targetLayer;
        public LayerMask conductiveLayer;

        [Header("Visuals")]
        public GameObject lightningPrefab;
        public float chainDelay = 0.08f;

        private List<Transform> _currentChain = new List<Transform>();
        private Camera _mainCamera;

        private void Awake()
        {
            _mainCamera = Camera.main;
            ServiceLocator.Register(this);
        }

        public void TryActivateWeave()
        {
            if (_mainCamera == null) return;

            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100f, targetLayer))
            {
                if (hit.transform != null)
                {
                    StartChain(hit.transform);
                }
            }
        }

        public void ForceActivateWeave(Transform target)
        {
            if (target != null)
            {
                StartChain(target);
            }
        }

        public void SetMaxTargets(int targets)
        {
            maxTargets = Mathf.Clamp(targets, 1, 10);
        }

        public int GetMaxTargets()
        {
            return maxTargets;
        }

        public void SetMaxChainDistance(float distance)
        {
            maxChainDistance = Mathf.Max(5f, distance);
        }

        public float GetMaxChainDistance()
        {
            return maxChainDistance;
        }

        public void ResetSystem()
        {
            _currentChain.Clear();
        }

        public bool HasActiveChain()
        {
            return _currentChain != null && _currentChain.Count > 0;
        }

        public void SetConductiveLayer(LayerMask layer)
        {
            conductiveLayer = layer;
        }

        public void SetTargetLayer(LayerMask layer)
        {
            targetLayer = layer;
        }

        public int GetCurrentChainCount()
        {
            return _currentChain != null ? _currentChain.Count : 0;
        }

        private void StartChain(Transform firstTarget)
        {
            _currentChain.Clear();
            _currentChain.Add(firstTarget);

            Collider[] hits = Physics.OverlapSphere(firstTarget.position, maxChainDistance, conductiveLayer);
            foreach (var hit in hits)
            {
                if (_currentChain.Count >= maxTargets) break;
                if (hit.transform != null && !_currentChain.Contains(hit.transform))
                {
                    _currentChain.Add(hit.transform);
                }
            }

            for (int i = 0; i < _currentChain.Count - 1; i++)
            {
                if (_currentChain[i] != null && _currentChain[i + 1] != null)
                {
                    CreateLightningVisual(_currentChain[i].position, _currentChain[i + 1].position);
                }
            }

            Debug.Log($"[LightningWeave] Chain started with {_currentChain.Count} targets");
        }

        public void ClearChain()
        {
            _currentChain.Clear();
        }

        private void CreateLightningVisual(Vector3 start, Vector3 end)
        {
            if (lightningPrefab != null)
            {
                GameObject bolt = Instantiate(lightningPrefab, start, Quaternion.identity);
                Destroy(bolt, 0.6f);
            }
            else
            {
                Debug.LogWarning("[LightningWeave] lightningPrefab is not assigned.");
            }
        }
    }
}