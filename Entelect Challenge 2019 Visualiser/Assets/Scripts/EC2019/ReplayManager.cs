using System.Collections;
using System.Collections.Generic;
using EC2019.Camera;
using EC2019.Entity;
using UnityEngine;

namespace EC2019 {
    public class ReplayManager : MonoBehaviour {
        public delegate void NextRoundUpdateWorms(Player player);

        public static event NextRoundUpdateWorms nextRoundUpdateWormsEvent;

        public ReplayRepo replayRepo;
        public float timePerRound = 1f;
        public float cameraMotionDelay = 0.5f;

        private List<Round> playerArounds;
        private List<Round> playerBrounds;
        private int currentRound = 1;

        private CameraController camera;

        void OnEnable() {
            ReplayLoader.roundsReadyEvent += RoundsReady;
        }

        private void Awake() {
            camera = FindObjectOfType<CameraController>();
        }

        void OnDisable() {
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

                var playerAroundCurrentWormId = playerAround.CurrentWormId;
                var playerBroundCurrentWormId = playerBround.CurrentWormId;

                if (currentRound >= 2) {
                    // camera.UpdatePosition(playerAroundCurrentWormId, playerBroundCurrentWormId);
                    camera.UpdateSize();

                    yield return new WaitForSeconds(cameraMotionDelay);
                }

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