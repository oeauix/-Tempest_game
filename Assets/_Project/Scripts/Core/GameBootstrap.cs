using UnityEngine;
using Tempest.Gameplay.Player;
using Tempest.World;

namespace Tempest.Core
{
    public class GameBootstrap : MonoBehaviour
    {
        [Header("Spawn Settings")]
        public Vector3 playerSpawnPosition = new Vector3(0, 2, 0);

        private void Awake()
        {
            CreatePlayer();
            CreateEnvironment();
            CreateLighting();
            
            Debug.Log("[GameBootstrap] Playable test scene initialized.");
        }

        private void CreatePlayer()
        {
            GameObject player = new GameObject("Player");
            player.transform.position = playerSpawnPosition;
            player.tag = "Player";

            // Character Controller
            var controller = player.AddComponent<CharacterController>();
            controller.height = 2f;
            controller.radius = 0.5f;

            // Player Controller
            var playerController = player.AddComponent<PlayerController>();
            playerController.walkSpeed = 6f;
            playerController.runSpeed = 10f;

            // Lightning Weave System
            var weave = player.AddComponent<LightningWeaveSystem>();
            weave.maxChainDistance = 25f;
            weave.maxTargets = 5;

            // Camera
            GameObject camObj = new GameObject("Main Camera");
            camObj.tag = "MainCamera";
            camObj.transform.position = playerSpawnPosition + new Vector3(0, 4, -8);
            camObj.transform.LookAt(player.transform.position + Vector3.up * 1.5f);

            var cam = camObj.AddComponent<Camera>();
            cam.fieldOfView = 60f;

            var camController = camObj.AddComponent<PlayerCameraController>();
            camController.target = player.transform;
            camController.distance = 8f;
            camController.height = 4f;
        }

        private void CreateEnvironment()
        {
            // Ground
            GameObject ground = GameObject.CreatePrimitive(PrimitiveType.Plane);
            ground.name = "Ground";
            ground.transform.position = Vector3.zero;
            ground.transform.localScale = new Vector3(30, 1, 30);

            // Add some conductive cubes
            for (int i = 0; i < 6; i++)
            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.name = $"Conductive_{i}";
                cube.transform.position = new Vector3(i * 5 - 12, 1.5f, 8);
                cube.transform.localScale = Vector3.one * 2f;

                var node = cube.AddComponent<ConductiveNode>();
                node.energyStored = 100f;

                // Visual feedback
                var renderer = cube.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.material.color = new Color(0.2f, 0.8f, 1f);
                }
            }
        }

        private void CreateLighting()
        {
            GameObject lightObj = new GameObject("Directional Light");
            lightObj.transform.rotation = Quaternion.Euler(50, -30, 0);

            var light = lightObj.AddComponent<Light>();
            light.type = LightType.Directional;
            light.color = Color.white;
            light.intensity = 1.2f;
        }
    }
}