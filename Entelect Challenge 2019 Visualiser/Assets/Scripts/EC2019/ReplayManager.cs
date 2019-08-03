using System.Collections;
using System.Collections.Generic;
using EC2019.Camera;
using EC2019.Entity;
using UnityEngine;

namespace EC2019 {
    public class ReplayManager : MonoBehaviour {
        public delegate void NextRoundUpdateWorms(Player player);

        public static event NextRoundUpdateWorms nextRoundUpdateWormsEvent;

        public delegate void NextRoundUpdateUI(Player playerA, Player playerB);

        public static event NextRoundUpdateUI nextRoundUpdateUIEvent;

        public ReplayRepo replayRepo;
        public float timePerRound = 1f;
        public float cameraMotionDelay = 0.5f;
        
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
            StartCoroutine(GameLoop());
        }

        private IEnumerator GameLoop() {
            while (true) {
                var round = replayRepo.GetRound(currentRound);
                
                var playerA = round.Opponents[0];
                var playerB = round.Opponents[1];

                if (nextRoundUpdateWormsEvent != null) {
                    nextRoundUpdateWormsEvent(playerA);
                    nextRoundUpdateWormsEvent(playerB);
                }

                if (tilesObjects == null || tilesObjects.Length == 0) {
                    tilesObjects = FindObjectsOfType<TileComponent>();
                }
                else {
                    PopulateNextRoundTiles(round.Map);
                }

                yield return new WaitForSeconds(timePerRound);

                if (nextRoundUpdateUIEvent != null) {
                    nextRoundUpdateUIEvent(playerA, playerB);
                }
                
                if (currentRound >= 2) {
                    singleCamera.UpdateSize();
                    dualCamera.UpdatePositions(playerA.Id, playerB.Id);

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