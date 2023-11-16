using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ClubEternal
{

    public class App : MonoBehaviour
    {
        public static App Instance { get; private set; }

        [SerializeField] string mainMenuSceneName;
        [SerializeField] string gameSceneName;
        [SerializeField] string loadingSplashSceneName;

        private Queue<string> loadQueue;
        private bool isLoading = false;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }

            loadQueue = new Queue<string>();
        }

        private void Start()
        {
            loadQueue.Enqueue(loadingSplashSceneName);
            loadQueue.Enqueue(mainMenuSceneName);
        }

        private void Update()
        {
            if (!isLoading && loadQueue.Count > 0)
            {
                StartCoroutine(LoadSceneInBackground(loadQueue.Dequeue()));
            }
        }

        private IEnumerator LoadSceneInBackground(string sceneName)
        {
            isLoading = true;
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

            while (!asyncLoad.isDone)
            {
                yield return null;
            }

            isLoading = false;
        }

        public void InitNewGame()
        {
            loadQueue.Enqueue(loadingSplashSceneName);
            loadQueue.Enqueue(gameSceneName);
        }
    }
}
