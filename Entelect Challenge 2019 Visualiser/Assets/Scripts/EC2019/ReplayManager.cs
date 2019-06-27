using System.Collections.Generic;
using EC2019.Entity;
using UnityEngine;

namespace EC2019 {
    public class ReplayManager : MonoBehaviour {

        public ReplayLoader replayLoader;

        public GameObject fauxTile;

        private List<Round> rounds;
        
        void Start() {
            ReplayLoader.roundsFinishedLoadingEvent += RoundsFinishedLoading;
        }
        
        void RoundsFinishedLoading(List<Round> rounds) {
            this.rounds = rounds;
            Debug.Log("Rounds finished loading!");
            
            PopulateGameMap();
        }

        private void PopulateGameMap() {
            var round = rounds[0];

            var map = round.Map;

            foreach (var col in map) {
                foreach (var row in col) {
                    var x = row.X;
                    var y = row.Y;
                    Instantiate(fauxTile, new Vector3(x, y, 0f), Quaternion.identity);
                }
            }
        }
        
    }
}