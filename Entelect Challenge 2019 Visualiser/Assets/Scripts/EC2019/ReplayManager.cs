using System.Collections;
using System.Collections.Generic;
using EC2019.Camera;
using EC2019.Entity;
using EC2019.Utility;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EC2019 {
    public class ReplayManager : MonoBehaviour {
        public delegate void NextRoundUpdateWorms(Player player);

        public static event NextRoundUpdateWorms nextRoundUpdateWormsEvent;

        public delegate void NextRoundUpdateUI(GlobalState round);

        public static event NextRoundUpdateUI nextRoundUpdateUIEvent;

        public VisualiserManager visualiserManager;

        public ReplayRepo replayRepo;
        public float timePerRound = 1f;
        public static float globalTimePerRound = 1f;
        public float cameraMotionDelay = 0.5f;

        public int currentRound = 1;

        private TileComponent[] tilesObjects;

        private SingleScreenCameraController singleCamera;

        void OnEnable() {
            ReplayLoader.roundsReadyEvent += RoundsReady;
        }

        private void Awake() {
            singleCamera = FindObjectOfType<SingleScreenCameraController>();
            currentRound = PlayerPrefs.GetInt(Constants.PlayerPrefKeys.RoundStep);
            timePerRound = PlayerPrefs.GetFloat(Constants.PlayerPrefKeys.StepTime);
            globalTimePerRound = timePerRound;
        }

        void OnDisable() {
            ReplayLoader.roundsReadyEvent -= RoundsReady;
        }

        private void RoundsReady() {
            StartCoroutine(GameLoop());
        }

        public void Update() {
            if (Input.GetKeyDown(KeyCode.Q)) {
                Application.Quit();
            }
        }

        private IEnumerator GameLoop() {
            while (true) {
                var round = replayRepo.GetRound(currentRound);
                globalTimePerRound = timePerRound;

                var playerA = round.Opponents[0];
                var playerB = round.Opponents[1];

                if (nextRoundUpdateWormsEvent != null) {
                    nextRoundUpdateWormsEvent(playerA);
                    nextRoundUpdateWormsEvent(playerB);
                }

                visualiserManager.processVisualisations(round.VisualizerEvents);

                yield return new WaitForSeconds(timePerRound / 2);

                if (tilesObjects == null || tilesObjects.Length == 0) {
                    tilesObjects = FindObjectsOfType<TileComponent>();
                }
                else {
                    PopulateNextRoundTiles(round.Map);
                }

                yield return new WaitForSeconds(timePerRound / 2);

                nextRoundUpdateUIEvent?.Invoke(round);

                if (currentRound >= 2) {
                    singleCamera.UpdateSize();
                    yield return new WaitForSeconds(cameraMotionDelay);
                }

                if (currentRound < replayRepo.totalRounds() - 1) {
                    currentRound++;
                }
                else {
                    string winningName = PlayerPrefs.GetString(Constants.PlayerPrefKeys.PlayerAName);
                    int winningScore = playerA.Score;
                    int winningPlayer = playerA.Id;
                    
                    if (playerA.Health == playerB.Health || currentRound == 399) {
                        if (playerA.Score < playerB.Score) {
                            winningName = PlayerPrefs.GetString(Constants.PlayerPrefKeys.PlayerBName);
                            winningScore = playerB.Score;
                            winningPlayer = playerB.Id;
                        }
                    }
                    else {
                        if (playerA.Health < playerB.Health) {
                            winningName = PlayerPrefs.GetString(Constants.PlayerPrefKeys.PlayerBName);
                            winningScore = playerB.Score;
                            winningPlayer = playerB.Id;
                        }
                    }
                    
                    PlayerPrefs.SetString(Constants.PlayerPrefKeys.WinningName, winningName);
                    PlayerPrefs.SetInt(Constants.PlayerPrefKeys.WinningScore, winningScore);
                    PlayerPrefs.SetInt(Constants.PlayerPrefKeys.WinningPlayer, winningPlayer);

                    SceneManager.LoadScene("EndGameScreen");
                }
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