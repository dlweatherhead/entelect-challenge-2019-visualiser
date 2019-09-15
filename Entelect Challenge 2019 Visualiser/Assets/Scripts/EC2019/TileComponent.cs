using System;
using EC2019.Entity;
using UnityEngine;
using Random = UnityEngine.Random;

namespace EC2019 {
    public class TileComponent : MonoBehaviour {
        public GameObject[] airTiles;
        public GameObject[] dirtTiles;
        public GameObject lavaTile;
        public GameObject spaceTile;
        public GameObject frozenTile;

        public GameObject healthPack;
        
        private static int randomAir = -1;
        private static int randomDirt = -1;

        public void Awake() {
            if(randomAir == -1) randomAir = Random.Range(0, 4);
            if(randomDirt == -1) randomDirt = Random.Range(0, 4);

            foreach (var airTile in airTiles) {
                airTile.SetActive(false);
            }
            foreach (var dirtTile in dirtTiles) {
                dirtTile.SetActive(false);
            }
            lavaTile.SetActive(false);
            spaceTile.SetActive(false);
            frozenTile.SetActive(false);
        }

        public void UpdateTile(Tile tile) {
            var y = gameObject.transform.position.y;
            transform.position = new Vector3(tile.X, y, tile.Y);

            airTiles[randomAir].SetActive(tile.TileType == TileType.AIR);
            dirtTiles[randomDirt].SetActive(tile.TileType == TileType.DIRT);
            spaceTile.SetActive(tile.TileType == TileType.SPACE);
            lavaTile.SetActive(tile.TileType == TileType.LAVA);

            if (tile.Occupier != null && tile.Occupier.RoundsUntilUnfrozen > 0) {
                frozenTile.SetActive(true);
            }
            else {
                frozenTile.SetActive(false);
            }

            if (tile.PowerUp != null && tile.PowerUp.Type.Equals(PowerUpType.HEALTH_PACK)) {
                healthPack.SetActive(true);
            }
            else {
                healthPack.SetActive(false);
            }
        }
    }
}