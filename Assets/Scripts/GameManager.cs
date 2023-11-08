﻿using UnityEngine;
using System;

namespace ClubEternal
{
    public class GameManager : MonoBehaviour 
    {
        public float PercentElapsed {
            get => levelTimeElapsed / levelDurationSec;
        }
        public bool IsGamePaused {
            get => state == GameState.SimPaused;
        }

        public Action RoundEndedHandler;
        public Action RoundStartedHandler;
        public Action GamePausedHandler;
        public Action GameResumedHandler;

        [Min(0.000001f)]
        [SerializeField] float levelDurationSec;

        private GameState state;
        private float levelTimeElapsed;

        private enum GameState
        {
            SimActive,
            SimPaused,
            ShopScreen
        }

        public void StartNextRound()
        {
            levelTimeElapsed = 0;
            state = GameState.SimActive;
            RoundStartedHandler?.Invoke();
        }

        public void PauseGame()
        {
            state = GameState.SimPaused;
            GamePausedHandler?.Invoke();
        }

        public void ResumeGame()
        {
            state = GameState.SimActive;
            GameResumedHandler?.Invoke();
        }

        private void EndCurrentRound()
        {
            RoundEndedHandler?.Invoke();
            state = GameState.ShopScreen;
        }

        private void Update()
        {
            if (state == GameState.SimActive)
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
