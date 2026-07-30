using UnityEngine;
using Tempest.Core;

namespace Tempest.Gameplay.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        [Header("Movement Settings")]
        public float walkSpeed = 6f;
        public float runSpeed = 10f;
        public float gravity = -20f;
        public float jumpHeight = 1.5f;

        [Header("Lightning Weave")]
        public LightningWeaveSystem weaveSystem;

        private CharacterController _controller;
        private Vector3 _velocity;
        private bool _isGrounded;
        private Camera _mainCamera;

        private void Awake()
        {
            _controller = GetComponent<CharacterController>();
            _mainCamera = Camera.main;

            if (_mainCamera == null)
            {
                Debug.LogWarning("[PlayerController] Main Camera not found!");
            }

            ServiceLocator.Register(this);
        }

        private void Update()
        {
            HandleMovement();
            HandleInput();
        }

        private void HandleMovement()
        {
            _isGrounded = _controller.isGrounded;
            if (_isGrounded && _velocity.y < 0)
                _velocity.y = -2f;

            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 move = Vector3.zero;
            if (_mainCamera != null)
            {
                move = _mainCamera.transform.right * horizontal + _mainCamera.transform.forward * vertical;
            }
            move.y = 0;

            float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
            _controller.Move(move * speed * Time.deltaTime);

            if (Input.GetButtonDown("Jump") && _isGrounded)
            {
                _velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            _velocity.y += gravity * Time.deltaTime;
            _controller.Move(_velocity * Time.deltaTime);
        }

        public bool IsGrounded()
        {
            return _isGrounded;
        }

        public float GetCurrentSpeed()
        {
            return _controller != null ? _controller.velocity.magnitude : 0f;
        }

        public void SetWalkSpeed(float speed)
        {
            walkSpeed = Mathf.Max(1f, speed);
        }

        private void HandleInput()
        {
            if (weaveSystem == null) return;

            if (Input.GetMouseButtonDown(0))
            {
                weaveSystem.TryActivateWeave();
            }

            // Touch input placeholder for future mobile support
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                weaveSystem.TryActivateWeave();
            }
        }
    }
}