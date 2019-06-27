using System.Collections.Generic;
using EC2019.Entity;
using UnityEngine;

namespace EC2019 {
    public class ReplayManager : MonoBehaviour {

        public ReplayLoader replayLoader;

        public GameObject airTile;
        public GameObject dirtTile;
        public GameObject spaceTile;

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
            var round = rounds[5];

            var map = round.Map;

            foreach (var row in map) {
                foreach (var tile in row) {
                    createTile(tile);
                }
            }
        }

        private void createTile(Tile tile) {
            if (TileType.AIR.Equals(tile.TileType)) {
                instantiateTile(airTile, tile.X, tile.Y);
            } else if (TileType.DIRT.Equals(tile.TileType)) {
                instantiateTile(dirtTile, tile.X, tile.Y);
            } else if (TileType.SPACE.Equals(tile.TileType)) {
                instantiateTile(spaceTile, tile.X, tile.Y);
            }
        }

        private void instantiateTile(GameObject o, float x, float y) {
            Instantiate(o, new Vector3(x, y, 0f), Quaternion.identity);
        }
        
    }
}