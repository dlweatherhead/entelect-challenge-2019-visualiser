using System.Collections.Generic;
using EC2019.Entity;
using UnityEngine;

namespace EC2019 {
    public class WormComponent : MonoBehaviour
    {
        public int playerId;
        public int id;
        
        void Start() {
            ReplayManager.nextRoundUpdateWormsEvent += UpdateWorm;
        }

        void UpdateWorm(Player player)
        {
            var worms = player.Worms;
            
            foreach (var worm in worms) {
                if (player.Id == playerId && worm.Id == id) {
                    UpdateWormPosition(worm.Position);
                }
            }
        }

        private void UpdateWormPosition(Vector2 position) {
            gameObject.transform.position = new Vector3(position.x, 0f, position.y);
        }
    }
}