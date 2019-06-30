using System.Collections;
using System.Collections.Generic;
using EC2019.Entity;
using UnityEngine;

namespace EC2019 {
    public class ReplayManager : MonoBehaviour {
        public delegate void NextRoundUpdateWorms(Worm worm);

        public static event NextRoundUpdateWorms nextRoundUpdateWormsEvent;

        public float timePerRound = 1f;
        private List<Round> rounds;

        private int currentRound = 1;

        void Start() {
            ReplayLoader.roundsFinishedLoadingEvent += RoundsFinishedLoading;
        }

        void RoundsFinishedLoading(List<Round> loadedRounds) {
            rounds = loadedRounds;

            Debug.Log("Starting Game Loop");


            StartCoroutine(GameLoop());
        }

        IEnumerator GameLoop() {
            while (true) {
                Debug.Log("Round: " + currentRound);
                var round = rounds[currentRound];

                // Notify all listeners of round start

                yield return new WaitForSeconds(timePerRound);
                currentRound++;
            }
        }
    }
}