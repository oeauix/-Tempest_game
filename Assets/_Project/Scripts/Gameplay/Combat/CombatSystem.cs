using UnityEngine;
using Tempest.Core;

namespace Tempest.Gameplay.Combat
{
    public class CombatSystem : MonoBehaviour
    {
        [Header("Combat Settings")]
        public float baseDamage = 25f;
        public float comboWindow = 1.2f;

        private float _lastAttackTime;
        private int _comboCount = 0;

        private void Awake()
        {
            ServiceLocator.Register(this);
        }

        public void PerformAttack(float damageMultiplier = 1f)
        {
            float currentTime = Time.time;

            if (currentTime - _lastAttackTime > comboWindow)
            {
                _comboCount = 1;
            }
            else
            {
                _comboCount = Mathf.Clamp(_comboCount + 1, 1, 4);
            }

            _lastAttackTime = currentTime;

            float finalDamage = baseDamage * damageMultiplier * (1f + (_comboCount - 1) * 0.25f);
            Debug.Log($"[Combat] Attack performed - Combo: {_comboCount} | Damage: {finalDamage:F1}");
        }

        public float GetCurrentDamageMultiplier()
        {
            return 1f + (_comboCount - 1) * 0.25f;
        }

        public int GetCurrentComboCount()
        {
            return _comboCount;
        }

        public void SetBaseDamage(float damage)
        {
            baseDamage = Mathf.Max(1f, damage);
        }

        public void ResetCombo()
        {
            _comboCount = 0;
        }

        public int GetCurrentCombo()
        {
            return _comboCount;
        }
    }
}