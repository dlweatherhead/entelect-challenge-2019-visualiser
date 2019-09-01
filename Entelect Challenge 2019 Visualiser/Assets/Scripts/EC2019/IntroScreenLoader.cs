using System;
using System.Collections;
using System.IO;
using EC2019.Utility;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EC2019 {
    public class IntroScreenLoader : MonoBehaviour {
        public string sceneName;

        public TMP_Text playerAName;
        public TMP_Text playerBName;

        public float loadSceneDelayTime = 3f;

        public GameObject[] delayedAppearObjects;

        void Start() {
            var cmdLine = new CommandLine();

            SetPlayerPrefs(cmdLine);
            LoadPlayerNames();

            StartCoroutine(PlayAnimationsAndLoadNextScene());
        }

        private IEnumerator PlayAnimationsAndLoadNextScene() {
            yield return new WaitForSeconds(0.5f);

            foreach (var o in delayedAppearObjects) {
                o.SetActive(true);
            }

            yield return new WaitForSeconds(loadSceneDelayTime);

            Debug.Log("Loading Replay Scene");
            SceneManager.LoadSceneAsync(sceneName);
        }

        private void SetPlayerPrefs(CommandLine cmdLine) {
            PlayerPrefs.SetInt(Constants.PlayerPrefKeys.RoundStep, cmdLine.GetRoundStep());
            PlayerPrefs.SetFloat(Constants.PlayerPrefKeys.StepTime, cmdLine.GetStepTime());
        }

        private void LoadPlayerNames() {
            var replayPath = PlayerPrefs.GetString(Constants.PlayerPrefKeys.SelectedReplay);

            var players = Directory.GetDirectories(replayPath + "/Round 001");

            foreach (var player in players) {
                if (player.Contains(Constants.PlayerA.FolderPrepend)) {
                    var playerNames = player.Split(new[] {Constants.PlayerA.FolderPrepend}, StringSplitOptions.None);
                    var playerName = playerNames[playerNames.Length - 1];
                    playerAName.text = playerName;
                    PlayerPrefs.SetString(Constants.PlayerPrefKeys.PlayerAName, playerName);
                }
                else if (player.Contains(Constants.PlayerB.FolderPrepend)) {
                    var playerNames = player.Split(new[] {Constants.PlayerB.FolderPrepend}, StringSplitOptions.None);
                    var playerName = playerNames[playerNames.Length - 1];
                    playerBName.text = playerName;
                    PlayerPrefs.SetString(Constants.PlayerPrefKeys.PlayerBName, playerName);
                }
            }
        }
    }
}