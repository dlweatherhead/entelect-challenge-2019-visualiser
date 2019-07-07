using System.Collections.Generic;
using EC2019.Entity;
using UnityEngine;

namespace EC2019 {
    public class FirstRoundLoader : MonoBehaviour
    {

        public ReplayRepo replayRepo;
        
        public GameObject airTile;
        public GameObject dirtTile;
        public GameObject spaceTile;

        public GameObject playerAWorm;
        public GameObject playerBWorm;

        void OnEnable() {
            ReplayLoader.roundsReadyEvent += RoundsReady;
        }

        void OnDisable()
        {
            ReplayLoader.roundsReadyEvent -= RoundsReady;
        }

        void RoundsReady()
        {
            var loadedRounds = replayRepo.GetPlayerARounds();

            PopulateGameMapForFirstRound(loadedRounds);
        }

        private void PopulateGameMapForFirstRound(IReadOnlyList<Round> rounds) {
            var round = rounds[0];

            foreach (var row in round.Map) {
                foreach (var tile in row) {
                    createTile(tile);
                }
            }

            foreach (var worm in round.PlayerA.Worms) {
                createWormPlayerA(worm);
            }
        }

        private void createTile(Tile tile) {
            if (tile.TileType == TileType.AIR)
                InstantiateObject(airTile, tile.X, tile.Y);
            else if (tile.TileType == TileType.DIRT)
                InstantiateObject(dirtTile, tile.X, tile.Y);
            else if (tile.TileType == TileType.SPACE)
                InstantiateObject(spaceTile, tile.X, tile.Y);
        }

        private void createWormPlayerA(Worm worm) {
            var wc = InstantiateObject(playerAWorm, worm.Position.x, worm.Position.y);
            wc.GetComponent<WormComponent>().id = worm.Id;
        }

        private static GameObject InstantiateObject(GameObject o, float x, float y) {
            return Instantiate(o, new Vector3(x, y, 0f), Quaternion.identity);
        }
    }
}