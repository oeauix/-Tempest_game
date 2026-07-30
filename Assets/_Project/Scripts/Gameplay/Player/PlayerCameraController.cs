using UnityEngine;

namespace Tempest.Gameplay.Player
{
    public class PlayerCameraController : MonoBehaviour
    {
        public Transform target;
        public float distance = 6f;
        public float height = 3f;
        public float sensitivity = 3f;

        private float _xRotation = 0f;
        private float _yRotation = 0f;

        private void LateUpdate()
        {
            if (target == null) return;

            if (Input.GetMouseButton(1))
            {
                _xRotation += Input.GetAxis("Mouse X") * sensitivity;
                _yRotation -= Input.GetAxis("Mouse Y") * sensitivity;
                _yRotation = Mathf.Clamp(_yRotation, -35f, 60f);
            }

            Quaternion rotation = Quaternion.Euler(_yRotation, _xRotation, 0);
            Vector3 position = target.position - rotation * new Vector3(0, 0, distance) + Vector3.up * height;

            transform.rotation = rotation;
            transform.position = position;
        }
    }
}