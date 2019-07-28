using System.Collections;
using System.Collections.Generic;
using EC2019.Camera;
using EC2019.Entity;
using UnityEngine;

namespace EC2019 {
    public class ReplayManager : MonoBehaviour {
        public delegate void NextRoundUpdateWorms(Player player);

        public static event NextRoundUpdateWorms nextRoundUpdateWormsEvent;

        public delegate void NextRoundUpdateTiles();

        public static event NextRoundUpdateTiles nextRoundUpdateTilesEvent;
        
        public delegate void NextRoundUpdateUI(Player playerA, Player playerB);

        public static event NextRoundUpdateUI nextRoundUpdateUIEvent;

        public ReplayRepo replayRepo;
        public float timePerRound = 1f;
        public float cameraMotionDelay = 0.5f;

        private List<Round> playerArounds;
        private List<Round> playerBrounds;
        private int currentRound = 1;

        private TileComponent[] tilesObjects;

        private SingleScreenCameraController singleCamera;
        private DualScreenCameraController dualCamera;

        void OnEnable() {
            ReplayLoader.roundsReadyEvent += RoundsReady;
        }

        private void Awake() {
            singleCamera = FindObjectOfType<SingleScreenCameraController>();
            dualCamera = FindObjectOfType<DualScreenCameraController>();
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

                if (nextRoundUpdateWormsEvent != null) {
                    nextRoundUpdateWormsEvent(playerAround.Player);
                    nextRoundUpdateWormsEvent(playerBround.Player);
                }

                if (tilesObjects == null || tilesObjects.Length == 0) {
                    tilesObjects = FindObjectsOfType<TileComponent>();
                }
                else {
                    PopulateNextRoundTiles(playerAround.Map);
                }

                yield return new WaitForSeconds(timePerRound);

                if (nextRoundUpdateUIEvent != null) {
                    nextRoundUpdateUIEvent(playerAround.Player, playerBround.Player);
                }
                
                if (currentRound >= 2) {
                    singleCamera.UpdateSize();
                    dualCamera.UpdatePositions(playerAroundCurrentWormId, playerBroundCurrentWormId);

                    yield return new WaitForSeconds(cameraMotionDelay);
                }
                
                currentRound++;

                // Break when round ends
            }
        }

        private void PopulateNextRoundTiles(IEnumerable<List<Tile>> map) {
            var i = 0;
            foreach (var row in map) {
                foreach (var tile in row) {
                    tilesObjects[i].UpdateTile(tile);
                    i++;
                }
            }
        }
    }
}