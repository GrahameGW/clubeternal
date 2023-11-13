using UnityEngine;
using Random = UnityEngine.Random;

namespace ClubEternal
{
    public class PersonSpawner : MonoBehaviour
    {
        [SerializeField] GameObject personPrefab;

        private GameManager manager;
        private float spawnDelay;
        private float timeUntilNextSpawn;

        private void Start()
        {
            manager = FindAnyObjectByType<GameManager>();
            manager.RoundStartedHandler += OnRoundStarted;
        }

        private void OnDestroy()
        {
            manager.RoundStartedHandler -= OnRoundStarted;
        }

        private void OnRoundStarted()
        {
            spawnDelay = manager.SpawnDelay();
            timeUntilNextSpawn = Random.Range(0f, spawnDelay);
        }

        private void Update()
        {
            if (manager.State != GameManager.GameState.SimActive) { return; }

            timeUntilNextSpawn -= Time.deltaTime;
            if (timeUntilNextSpawn <= 0f)
            {
                timeUntilNextSpawn = spawnDelay;
                SpawnPerson();
            } 
        }

        private void SpawnPerson()
        {
            var person = Instantiate(personPrefab, transform.root);
            person.transform.position = transform.position;
        }
    }
}
