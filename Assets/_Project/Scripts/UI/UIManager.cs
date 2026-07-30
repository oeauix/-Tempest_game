using UnityEngine;
using Tempest.Core;

namespace Tempest.UI
{
    public class UIManager : MonoBehaviour
    {
        public GameObject hudCanvas;
        public GameObject pauseMenu;

        private void Awake()
        {
            ServiceLocator.Register(this);
        }

        public void ShowHUD(bool show)
        {
            if (hudCanvas != null)
                hudCanvas.SetActive(show);
        }

        public void TogglePauseMenu()
        {
            if (pauseMenu != null)
                pauseMenu.SetActive(!pauseMenu.activeSelf);
        }
    }
}