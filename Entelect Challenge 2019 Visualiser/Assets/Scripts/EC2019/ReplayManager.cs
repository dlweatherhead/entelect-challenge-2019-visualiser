using System.Collections;
using System.Collections.Generic;
using EC2019.Entity;
using UnityEngine;

namespace EC2019 {
    public class ReplayManager : MonoBehaviour {
        public delegate void NextRoundUpdateWorms(List<Worm> worm);

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
                
                Debug.Log("Current Worm: " + round.CurrentWormId);
                
                if (nextRoundUpdateWormsEvent != null) {
                    nextRoundUpdateWormsEvent(round.PlayerA.Worms);
                    var opponents = round.Opponents;
                    foreach (var opponent in opponents) {
                        nextRoundUpdateWormsEvent(opponent.Worms);
                    }
                }

                yield return new WaitForSeconds(timePerRound);
                currentRound++;
            }
        }
    }
}