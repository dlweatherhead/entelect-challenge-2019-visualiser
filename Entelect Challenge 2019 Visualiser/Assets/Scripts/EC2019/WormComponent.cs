using System.Collections.Generic;
using EC2019.Entity;
using UnityEngine;

namespace EC2019 {
    public class WormComponent : MonoBehaviour {

        public int id;
        
        void Start() {
            ReplayManager.nextRoundUpdateWormsEvent += UpdateWorm;
        }

        void UpdateWorm(List<Worm> worms) {
            foreach (var worm in worms) {
                if (worm.Id == id) {
                    UpdateWormPosition(worm.Position);
                }
            }
        }

        private void UpdateWormPosition(Vector2 position) {
            gameObject.transform.position = position;
        }


    }
}