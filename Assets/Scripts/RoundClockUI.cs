﻿using UnityEngine;
using UnityEngine.UI;

namespace ClubEternal
{
    public class RoundClockUI : MonoBehaviour
    {
        [SerializeField] Image clock;

        private GameManager manager;

        private void Start()
        {
            manager = FindAnyObjectByType<GameManager>();
        }

        private void Update()
        {
            clock.fillAmount = manager.PercentElapsed;
        }
    }
}
