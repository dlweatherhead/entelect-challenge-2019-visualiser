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

        public bool isEditor;

        public float editorStepTime = 1f;
        public int editorRoundStep = 1;
        public string editorMatchRound = "../Matches/2019.07.30.10.00.20";
        public string editorPlayerAName = "Keanu The Reeviest";
        public string editorPlayerBName = "Ozymandias the Sassiest";

        void Start() {

            if (isEditor) {
                PlayerPrefs.SetString(Constants.PlayerPrefKeys.SelectedReplay, editorMatchRound);
                PlayerPrefs.SetInt(Constants.PlayerPrefKeys.RoundStep, editorRoundStep);
                PlayerPrefs.SetFloat(Constants.PlayerPrefKeys.StepTime, editorStepTime);
                PlayerPrefs.SetString(Constants.PlayerPrefKeys.PlayerAName, editorPlayerAName);
                PlayerPrefs.SetString(Constants.PlayerPrefKeys.PlayerBName, editorPlayerBName);
            }
            else {
                var cmdLine = new CommandLine();
        
                SetPlayerPrefs(cmdLine);
                LoadPlayerNames();
            }
            
            playerAName.text = PlayerPrefs.GetString(Constants.PlayerPrefKeys.PlayerAName);
            playerBName.text = PlayerPrefs.GetString(Constants.PlayerPrefKeys.PlayerBName);

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
            var rootApplicationPath = Application.dataPath + "/..";
            var replayPath = rootApplicationPath + "/" + cmdLine.GetMatchRound();
        
            PlayerPrefs.SetString(Constants.PlayerPrefKeys.SelectedReplay, replayPath);
            PlayerPrefs.SetInt(Constants.PlayerPrefKeys.RoundStep, cmdLine.GetRoundStep());
            PlayerPrefs.SetFloat(Constants.PlayerPrefKeys.StepTime, cmdLine.GetStepTime());
        }

        private void LoadPlayerNames() {
            var replayPath = PlayerPrefs.GetString(Constants.PlayerPrefKeys.SelectedReplay);
        
            var players = Directory.GetDirectories(replayPath + "/Round 001");

            foreach (var player in players) {
                if (player.Contains(Constants.PlayerA.FolderPrepend)) {
                    var names = player.Split(new string[] { Constants.PlayerA.FolderPrepend }, StringSplitOptions.None);
                    PlayerPrefs.SetString(Constants.PlayerPrefKeys.PlayerAName, names[names.Length-1]);
                } else if (player.Contains(Constants.PlayerB.FolderPrepend)) {
                    var names = player.Split(new string[] { Constants.PlayerB.FolderPrepend }, StringSplitOptions.None);
                    PlayerPrefs.SetString(Constants.PlayerPrefKeys.PlayerBName, names[names.Length-1]);
                }
            }
        }

        private void PopulateScreen() {
        
        }
    }
}
