using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tempest.Core
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        public enum GameState { MainMenu, Playing, Paused, Loading }
        public GameState CurrentState { get; private set; } = GameState.MainMenu;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public void ChangeState(GameState newState)
        {
            CurrentState = newState;
            Debug.Log($"Game state changed to: {newState}");
        }

        public void LoadScene(string sceneName)
        {
            if (string.IsNullOrEmpty(sceneName))
            {
                Debug.LogError("Scene name cannot be null or empty.");
                return;
            }

            ChangeState(GameState.Loading);
            var operation = SceneManager.LoadSceneAsync(sceneName);
            if (operation != null)
            {
                operation.completed += _ => ChangeState(GameState.Playing);
            }
        }
    }
}