using System.Collections.Generic;
using EC2019.Entity;
using EC2019.Utility;
using UnityEngine;

namespace EC2019 {
    public class FirstRoundLoader : MonoBehaviour {
        public ReplayRepo replayRepo;

        public GameObject genericTile;

        public GameObject playerAWormAgent;
        public GameObject playerAWormCommando;
        public GameObject playerAWormTechnologist;
        public GameObject playerBWormAgent;
        public GameObject playerBWormCommando;
        public GameObject playerBWormTechnologist;

        void OnEnable() {
            ReplayLoader.roundsReadyEvent += RoundsReady;
        }

        void OnDisable() {
            ReplayLoader.roundsReadyEvent -= RoundsReady;
        }

        void RoundsReady() {
            var firstRound = replayRepo.GetRound(0);

            PopulateGameMapForFirstRound(firstRound.Map);
            PopulatePlayerAWorms(firstRound.Opponents[0].Worms);
            PopulatePlayerBWorms(firstRound.Opponents[1].Worms);
        }

        private void PopulateGameMapForFirstRound(IEnumerable<List<Tile>> map) {
            var parent = new GameObject(Constants.ParentNames.TilesHolder);
            foreach (var row in map) {
                foreach (var tile in row) {
                    createTile(tile, parent);
                }
            }
        }

        private void PopulatePlayerAWorms(IEnumerable<Worm> playerAWorms) {
            var parent = new GameObject(Constants.ParentNames.PlayerAHolder);
            foreach (var worm in playerAWorms) {
                createWormPlayerA(worm, parent);
            }
        }

        private void PopulatePlayerBWorms(IEnumerable<Worm> playerBWorms) {
            var parent = new GameObject(Constants.ParentNames.PlayerBHolder);
            foreach (var worm in playerBWorms) {
                createWormPlayerB(worm, parent);
            }
        }

        private void createTile(Tile tile, GameObject parent) {
            var o = InstantiateObject(genericTile, tile.X, tile.Y, parent);
            o.GetComponent<TileComponent>().UpdateTile(tile);
        }

        private void createWormPlayerA(Worm worm, GameObject parent) {
            var profession = worm.Profession;
            var toInstantiate = playerAWormAgent;
            if (profession.Equals(Constants.Worm.Profession.Agent)) {
                toInstantiate = playerAWormAgent;
            } else if (profession.Equals(Constants.Worm.Profession.Commando)) {
                toInstantiate = playerAWormCommando;
            } else if (profession.Equals(Constants.Worm.Profession.Technologist)) {
                toInstantiate = playerAWormTechnologist;
            }
            var wc = InstantiateObject(toInstantiate, worm.Position.x, worm.Position.y, parent);
            wc.GetComponent<WormComponent>().id = worm.Id;
        }

        private void createWormPlayerB(Worm worm, GameObject parent) {
            var profession = worm.Profession;
            var toInstantiate = playerBWormAgent;
            if (profession.Equals(Constants.Worm.Profession.Agent)) {
                toInstantiate = playerBWormAgent;
            } else if (profession.Equals(Constants.Worm.Profession.Commando)) {
                toInstantiate = playerBWormCommando;
            } else if (profession.Equals(Constants.Worm.Profession.Technologist)) {
                toInstantiate = playerBWormTechnologist;
            }
            var wc = InstantiateObject(toInstantiate, worm.Position.x, worm.Position.y, parent);
            wc.GetComponent<WormComponent>().id = worm.Id;
        }

        private static GameObject InstantiateObject(GameObject o, float x, float y, GameObject parent) {
            return Instantiate(o, new Vector3(x, 0f, y), Quaternion.identity, parent.transform);
        }
    }
}