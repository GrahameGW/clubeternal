using UnityEngine;

namespace ClubEternal
{
    public class ShopScreenUI : MonoBehaviour
    {
        private GameManager manager;

        private void Start()
        {
            manager = FindAnyObjectByType<GameManager>();
            manager.RoundEndedHandler += OnRoundEnded;

        }

        private void OnDestroy()
        {
            manager.RoundEndedHandler -= OnRoundEnded;
        }

        public void FinishShopping()
        {
            manager.StartNextRound();
            gameObject.SetActive(false);
        }

        private void OnRoundEnded()
        {
            gameObject.SetActive(true);
        }
    }
}
