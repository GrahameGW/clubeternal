using UnityEngine;

namespace ClubEternal
{
    public class MainMenuManager : MonoBehaviour
    {
        public void StartNewGame()
        {
            App.Instance.InitNewGame();
        }

        public void OpenCredits()
        {

        }

        public void ExitApp()
        {
            Application.Quit();
        }
    }
}
