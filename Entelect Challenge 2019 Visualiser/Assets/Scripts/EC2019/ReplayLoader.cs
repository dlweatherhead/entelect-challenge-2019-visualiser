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

        private void Start() {
            var absoluteDirectory = PlayerPrefs.GetString(Constants.PlayerPrefKeys.SelectedReplay);

            var roundsList = Directory.GetDirectories(absoluteDirectory);

            var globalStates = new List<GlobalState>();
            foreach (var round in roundsList) {
                var jsonMap = round + "/GlobalState.json";
                globalStates.Add(new JsonFileParser<GlobalState>(jsonMap).GetSerializedData());
            }

            roundsFinishedLoadingEvent?.Invoke(globalStates);

            roundsReadyEvent?.Invoke();
        }
    }
}