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

        public ReplayRepo replayRepo;
        public float timePerRound = 1f;
        public float cameraMotionDelay = 0.5f;

        public GameObject airTile;
        public GameObject dirtTile;
        public GameObject spaceTile;

        private List<Round> playerArounds;
        private List<Round> playerBrounds;
        private int currentRound = 1;

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

                if (currentRound >= 2) {
                    if (singleCamera.isActiveAndEnabled) {
                        singleCamera.UpdateSize();
                    }
                    else if (dualCamera.isActiveAndEnabled) {
                        dualCamera.UpdatePositions(playerAroundCurrentWormId, playerBroundCurrentWormId);
                    }

                    yield return new WaitForSeconds(cameraMotionDelay);
                }

                if (nextRoundUpdateWormsEvent != null) {
                    nextRoundUpdateWormsEvent(playerAround.Player);
                    nextRoundUpdateWormsEvent(playerBround.Player);
                }

                DestroyTiles();
                PopulateNextRoundTiles(playerAround.Map);

                yield return new WaitForSeconds(timePerRound);
                currentRound++;
            }
        }

        private void DestroyTiles() {
            var tiles = GameObject.FindGameObjectsWithTag("Tile");
            foreach (var tile in tiles) {
                Destroy(tile);
            }
        }

        private void PopulateNextRoundTiles(IEnumerable<List<Tile>> map) {
            foreach (var row in map) {
                foreach (var tile in row) {
                    createTile(tile);
                }
            }
        }

        private void createTile(Tile tile) {
            if (tile.TileType == TileType.AIR)
                InstantiateObject(airTile, tile.X, tile.Y);
            else if (tile.TileType == TileType.DIRT)
                InstantiateObject(dirtTile, tile.X, tile.Y);
            else if (tile.TileType == TileType.SPACE)
                InstantiateObject(spaceTile, tile.X, tile.Y);
        }

        private static GameObject InstantiateObject(GameObject o, float x, float y) {
            return Instantiate(o, new Vector3(x, 0f, y), Quaternion.identity);
        }
    }
}