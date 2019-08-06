using System.Collections.Generic;
using System.IO;
using System.Linq;
using EC2019.Entity;
using EC2019.Utility;
using UnityEngine;

namespace EC2019 {
    public class ReplayLoader : MonoBehaviour {
        public delegate void RoundsFinishedLoading(List<GlobalState> playerRounds);

        public delegate void RoundsReady();

        public static event RoundsFinishedLoading roundsFinishedLoadingEvent;

        public static event RoundsReady roundsReadyEvent;

        public GameObject loadingScreen;
        
        private void Start() {
            var absoluteDirectory = PlayerPrefs.GetString(Constants.PlayerPrefKeys.SelectedReplay);

            var roundsList = Directory.GetDirectories(absoluteDirectory);

            var globalStates = roundsList.Select(round => round + Constants.Paths.GlobalStateFilename)
                .Select(jsonMap => new JsonFileParser<GlobalState>(jsonMap).GetSerializedData())
                .ToList();

            roundsFinishedLoadingEvent?.Invoke(globalStates);

            roundsReadyEvent?.Invoke();
            
            loadingScreen.SetActive(false);
        }
    }
}