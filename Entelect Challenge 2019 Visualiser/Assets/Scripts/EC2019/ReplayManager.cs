using System.Collections;
using System.Collections.Generic;
using EC2019.Entity;
using UnityEngine;

namespace EC2019 {
    public class ReplayManager : MonoBehaviour {
        public delegate void NextRoundUpdateWorms(Player player);

        public static event NextRoundUpdateWorms nextRoundUpdateWormsEvent;

        public ReplayRepo replayRepo;
        public float timePerRound = 1f;
        
        private List<Round> playerArounds;
        private List<Round> playerBrounds;
        private int currentRound = 1;

        void OnEnable() {
            ReplayLoader.roundsReadyEvent += RoundsReady;
        }

        void OnDisable()
        {
            ReplayLoader.roundsReadyEvent -= RoundsReady;
        }

        private void RoundsReady() {
            playerArounds = replayRepo.GetPlayerARounds();
            playerBrounds = replayRepo.GetPlayerBRounds();

            StartCoroutine(GameLoop());
        }

        private IEnumerator GameLoop() {
            while (true) {
                var playerAround = playerArounds[currentRound];
                var playerBround = playerBrounds[currentRound];
                
                if (nextRoundUpdateWormsEvent != null) {
                    nextRoundUpdateWormsEvent(playerAround.Player);
                    nextRoundUpdateWormsEvent(playerBround.Player);
                }

                yield return new WaitForSeconds(timePerRound);
                currentRound++;
            }
        }
    }
}