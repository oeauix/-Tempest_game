using UnityEngine;
using Tempest.Core;

namespace Tempest.Gameplay.AI
{
    public enum EnemyState { Idle, Patrol, Chase, Attack, Stunned }

    public class EnemyAI : MonoBehaviour
    {
        [Header("AI Settings")]
        public float detectionRange = 15f;
        public float attackRange = 3f;
        public float moveSpeed = 4f;

        public EnemyState currentState = EnemyState.Idle;

        private Transform _player;
        private float _nextAttackTime;

        private void Awake()
        {
            _player = GameObject.FindWithTag("Player")?.transform;
            if (_player == null)
            {
                Debug.LogWarning("[EnemyAI] Player not found at Awake.");
            }
        }

        private void Update()
        {
            if (_player == null)
            {
                _player = GameObject.FindWithTag("Player")?.transform;
                if (_player == null) return;
            }

            float distance = Vector3.Distance(transform.position, _player.position);

            switch (currentState)
            {
                case EnemyState.Idle:
                    if (distance < detectionRange)
                        currentState = EnemyState.Chase;
                    break;

                case EnemyState.Chase:
                    if (distance > detectionRange)
                        currentState = EnemyState.Idle;
                    else if (distance < attackRange)
                        currentState = EnemyState.Attack;

                    transform.position = Vector3.MoveTowards(transform.position, _player.position, moveSpeed * Time.deltaTime);
                    break;

                case EnemyState.Attack:
                    if (Time.time >= _nextAttackTime)
                    {
                        AttackPlayer();
                        _nextAttackTime = Time.time + 1.5f;
                    }
                    if (distance > attackRange)
                        currentState = EnemyState.Chase;
                    break;
            }
        }

        private void AttackPlayer()
        {
            Debug.Log("[EnemyAI] Enemy attacks player!");
            // TODO: Apply damage to player
        }
    }
}