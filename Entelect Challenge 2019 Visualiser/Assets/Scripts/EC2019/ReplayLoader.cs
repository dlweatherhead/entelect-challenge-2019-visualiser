using System.Collections.Generic;
using System.IO;
using System.Linq;
using DLW.Directory;
using EC2019.Entity;
using UnityEngine;
using EC2019.Utility;

namespace EC2019 {
    public class ReplayLoader : MonoBehaviour {
        
        public delegate void RoundsFinishedLoading(Dictionary<string, List<Round>> playerRounds);
        public static event RoundsFinishedLoading roundsFinishedLoadingEvent;

        public delegate void RoundsReady();

        public static event RoundsReady roundsReadyEvent;

        private void Start()
        {
            var absoluteDirectory = PlayerPrefs.GetString(Constants.PlayerPrefKeys.SelectedReplay);
                
            var roundsList = Directory.GetDirectories(absoluteDirectory);

            var roundsPlayerA = (from round in roundsList 
                select Directory.GetDirectories(round)[0] into playerA 
                select playerA + "/JsonMap.json" into jsonMap 
                select new JsonFileParser<Round>(jsonMap).GetSerializedData()).ToList();
            
            var roundsPlayerB = (from round in roundsList 
                select Directory.GetDirectories(round)[1] into playerB
                select playerB + "/JsonMap.json" into jsonMap 
                select new JsonFileParser<Round>(jsonMap).GetSerializedData()).ToList();

            var loadedRounds = new Dictionary<string, List<Round>>
            {
                {"playerA", roundsPlayerA},
                {"playerB", roundsPlayerB}
            };
            roundsFinishedLoadingEvent?.Invoke(loadedRounds);
            
            roundsReadyEvent?.Invoke();
        }

        private void processDirectories(string absoluteDirectory) {
            
            List<Round> playerARounds = new List<Round>();
            List<Round> playerBRounds = new List<Round>();
            
            // Loop through all rounds
            var roundsList = Directory.GetDirectories(absoluteDirectory);

            string playerAName;
            string playerBName;

            if (roundsList[0].Contains("A")) {
                playerAName = roundsList[0];
                playerBName = roundsList[1];
            }
            else {
                playerAName = roundsList[1];
                playerBName = roundsList[0];
            }
            
            // Fetch each player
            foreach (var round in roundsList) {
                var playerFolders = Directory.GetDirectories(round);
                foreach (var player in playerFolders) {
                    var jsonMap = player + "/JsonMap.json";
                    if (player.Contains("A")) {
                        playerARounds.Add(new JsonFileParser<Round>(jsonMap).GetSerializedData());
                    }

                    if (player.Contains("B")) {
                        playerBRounds.Add(new JsonFileParser<Round>(jsonMap).GetSerializedData());
                    }
                }
            }
            

            // Add player round detail to player
            Dictionary<string, List<Round>> playerRounds = new Dictionary<string, List<Round>>();
            playerRounds.Add(playerAName, playerARounds);
            playerRounds.Add(playerBName, playerBRounds);
            
            Debug.Log("Finished Loading all rounds for players");
        }
    }
}