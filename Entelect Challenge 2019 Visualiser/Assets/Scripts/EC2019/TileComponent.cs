using EC2019.Entity;
using UnityEngine;

namespace EC2019 {
    public class TileComponent : MonoBehaviour {
        public GameObject airTile;
        public GameObject dirtTile;
        public GameObject lavaTile;
        public GameObject spaceTile;

        public void UpdateTile(Tile tile) {
            var y = gameObject.transform.position.y;
            transform.position = new Vector3(tile.X, y, tile.Y);

            airTile.SetActive(tile.TileType == TileType.AIR);
            dirtTile.SetActive(tile.TileType == TileType.DIRT);
            spaceTile.SetActive(tile.TileType == TileType.SPACE);
            lavaTile.SetActive(tile.TileType == TileType.LAVA);
        }
    }
}