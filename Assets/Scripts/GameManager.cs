using UnityEngine;
using System;

namespace ClubEternal
{
    public class GameManager : MonoBehaviour 
    {
        public float PercentElapsed {
            get => levelTimeElapsed / levelDurationSec;
        }
        public bool IsGamePaused {
            get => State == GameState.SimPaused;
        }
        public int CurrentRound { get; private set; }

        public Action RoundEndedHandler;
        public Action RoundStartedHandler;
        public Action GamePausedHandler;
        public Action GameResumedHandler;

        [Min(0.000001f)]
        [SerializeField] float levelDurationSec;
        [SerializeField] AnimationCurve spawnFrequencyCurve;
        [SerializeField] int spawnCurveMaxLevel;
        [SerializeField] float spawnCurveMaxSpawnDelay;
        [Min(0.000001f)]
        [SerializeField] float spawnDelayReductionAfterMax;

        public GameState State;
        private float levelTimeElapsed;

        public enum GameState
        {
            SimActive,
            SimPaused,
            ShopScreen
        }

        private void Start()
        {
            CurrentRound = 0;
            StartNextRound();
        }

        public void StartNextRound()
        {
            levelTimeElapsed = 0;
            CurrentRound++;
            State = GameState.SimActive;
            RoundStartedHandler?.Invoke();
        }

        public void PauseGame()
        {
            State = GameState.SimPaused;
            GamePausedHandler?.Invoke();
        }

        public void ResumeGame()
        {
            State = GameState.SimActive;
            GameResumedHandler?.Invoke();
        }

        public float SpawnDelay()
        {
            if ( CurrentRound > spawnCurveMaxLevel)
            {
                float baseY = spawnFrequencyCurve.Evaluate(1f);
                float roundDelta = CurrentRound - spawnCurveMaxLevel;
                return baseY * Mathf.Pow(spawnDelayReductionAfterMax, roundDelta);
            }
            else
            {
                int zeroedRound = CurrentRound - 1;
                float curveX = (float)zeroedRound / spawnCurveMaxLevel;
                float curveY = spawnFrequencyCurve.Evaluate(curveX);
                return curveY * spawnCurveMaxSpawnDelay;
            }
        }

        private void EndCurrentRound()
        {
            RoundEndedHandler?.Invoke();
            State = GameState.ShopScreen;
        }

        private void Update()
        {
            if (State == GameState.SimActive)
            {
                levelTimeElapsed += Time.deltaTime;
                if (PercentElapsed >= 1f)
                {
                    EndCurrentRound();
                }
            }
        }
    }
}
