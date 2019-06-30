using System.Collections;
using System.Collections.Generic;
using EC2019.Entity;
using UnityEngine;

namespace EC2019 {
    public class ReplayManager : MonoBehaviour {

        public ReplayLoader replayLoader;

        public GameObject airTile;
        public GameObject dirtTile;
        public GameObject spaceTile;

        public GameObject playerAWorm;
        public GameObject playerBWorm;

        public float timePerRound = 1f;
        
        private List<Round> rounds;
        
        void Start() {
            ReplayLoader.roundsFinishedLoadingEvent += RoundsFinishedLoading;
        }

        void RoundsFinishedLoading(List<Round> loadedRounds) {
            rounds = loadedRounds;
            Debug.Log("Rounds finished loading!");
            
            StartCoroutine(PopulateGameMap());
        }

        private IEnumerator PopulateGameMap() {
            foreach (var round in rounds) {
                foreach (var row in round.Map) {
                    foreach (var tile in row) {
                        createTile(tile);
                    }
                }
                
                foreach (var worm in round.PlayerA.Worms) {
                    createWormPlayerA(worm);
                }

                foreach (var opponent in round.Opponents) {
                    foreach (var worm in opponent.Worms) {
                        createWormPlayerB(worm);
                    }
                }
                
                yield return new WaitForSeconds(timePerRound);
                
                foreach (var t in GameObject.FindGameObjectsWithTag("Tile")) {
                    Destroy(t);
                }
                foreach (var w in GameObject.FindGameObjectsWithTag("Worm")) {
                    Destroy(w);
                }
            }
        }

        private void createTile(Tile tile) {
            if (tile.TileType == TileType.AIR)
                InstantiateObject(airTile, tile.X, tile.Y);
            else if (tile.TileType == TileType.DIRT)
                InstantiateObject(dirtTile, tile.X, tile.Y);
            else if (tile.TileType == TileType.SPACE) InstantiateObject(spaceTile, tile.X, tile.Y);
        }

        private void createWormPlayerA(Worm worm) {
            InstantiateObject(playerAWorm, worm.Position.x, worm.Position.y);
        }
        
        private void createWormPlayerB(Worm worm) {
            InstantiateObject(playerBWorm, worm.Position.x, worm.Position.y);
        }

        private void InstantiateObject(GameObject o, float x, float y) {
            Instantiate(o, new Vector3(x, y, 0f), Quaternion.identity);
        }
        
    }
}