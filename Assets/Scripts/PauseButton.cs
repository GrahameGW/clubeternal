using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ClubEternal
{
    [RequireComponent(typeof(Image))]
    public class PauseButton : MonoBehaviour
    {
        [SerializeField] Sprite pauseIconSprite;
        [SerializeField] Sprite playIconSprite;

        private Image image;
        private GameManager gameManager;

        private void Awake()
        {
            gameManager = FindAnyObjectByType<GameManager>();
            image = GetComponent<Image>(); 
        }

        public void TogglePause()
        {
            if (gameManager.IsGamePaused)
            {
                image.sprite = pauseIconSprite;
                gameManager.ResumeGame();
            }
            else
            {
                image.sprite = playIconSprite;
                gameManager.PauseGame();
            }
            
            // deselects all UI, not just this button. 
            EventSystem.current.SetSelectedGameObject(null);
        }
    }
}
