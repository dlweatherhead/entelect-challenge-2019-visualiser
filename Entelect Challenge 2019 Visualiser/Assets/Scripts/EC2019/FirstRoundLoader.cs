using System.Collections.Generic;
using EC2019.Entity;
using UnityEngine;

namespace EC2019 {
    public class FirstRoundLoader : MonoBehaviour {
        public ReplayRepo replayRepo;

        public GameObject genericTile;

        public GameObject playerAWorm;
        public GameObject playerBWorm;

        void OnEnable() {
            ReplayLoader.roundsReadyEvent += RoundsReady;
        }

        void OnDisable() {
            ReplayLoader.roundsReadyEvent -= RoundsReady;
        }

        void RoundsReady() {
            var loadedRounds = replayRepo.GetPlayerARounds();

            PopulateGameMapForFirstRound(loadedRounds[0].Map);
            PopulatePlayerAWorms(loadedRounds[0].Player.Worms);
            PopulatePlayerBWorms(loadedRounds[1].Player.Worms);
        }

        private void PopulateGameMapForFirstRound(IEnumerable<List<Tile>> map) {
            foreach (var row in map) {
                foreach (var tile in row) {
                    createTile(tile);
                }
            }
        }

        private void PopulatePlayerAWorms(IEnumerable<Worm> playerAWorms) {
            foreach (var worm in playerAWorms) {
                createWormPlayerA(worm);
            }
        }

        private void PopulatePlayerBWorms(IEnumerable<Worm> playerBWorms) {
            foreach (var worm in playerBWorms) {
                createWormPlayerB(worm);
            }
        }

        private void createTile(Tile tile) {
            var o = InstantiateObject(genericTile, tile.X, tile.Y);
            o.GetComponent<TileComponent>().UpdateTile(tile);
        }

        private void createWormPlayerA(Worm worm) {
            var wc = InstantiateObject(playerAWorm, worm.Position.x, worm.Position.y);
            wc.GetComponent<WormComponent>().id = worm.Id;
        }

        private void createWormPlayerB(Worm worm) {
            var wc = InstantiateObject(playerBWorm, worm.Position.x, worm.Position.y);
            wc.GetComponent<WormComponent>().id = worm.Id;
        }

        private static GameObject InstantiateObject(GameObject o, float x, float y) {
            return Instantiate(o, new Vector3(x, 0f, y), Quaternion.identity);
        }
    }
}