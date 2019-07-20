using EC2019.Entity;
using EC2019.Utility;
using UnityEngine;

namespace EC2019 {
    public class TileComponent : MonoBehaviour {
        public Tile tileDetail;

        public GameObject airTile;
        public GameObject dirtTile;
        public GameObject spaceTile;

        public void UpdateTile(Tile tile) {
            airTile.SetActive(false);
            dirtTile.SetActive(false);
            spaceTile.SetActive(false);

            var y = gameObject.transform.position.y;
            transform.position = new Vector3(tile.X, y, tile.Y);

            if (tile.TileType == TileType.AIR)
                airTile.SetActive(true);
            else if (tile.TileType == TileType.DIRT)
                dirtTile.SetActive(true);
            else if (tile.TileType == TileType.SPACE)
                spaceTile.SetActive(true);
        }
    }
}