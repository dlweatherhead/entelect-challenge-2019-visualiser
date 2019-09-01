using System;
using System.Collections;
using System.Collections.Generic;
using EC2019.Entity;
using UnityEngine;

namespace EC2019 {
    public class WormComponent : MonoBehaviour {
        public int playerId;
        public int id;

        public float moveSpeed = 1f;

        public GameObject wormGrave;
        
        private Vector3 target;
        private bool isMoving;

        void Start() {
            ReplayManager.nextRoundUpdateWormsEvent += UpdateWorm;
        }

        void UpdateWorm(Player player) {
            var worms = player.Worms;

            foreach (var worm in worms) {
                if (player.Id == playerId && worm.Id == id) {
                    if (worm.Health <= 0) {
                        StartCoroutine(DeathAnimationAndDestroyWorm());
                    }
                    else {
                        UpdateWormPosition(worm.Position);                        
                    }
                }
            }
        }

        private IEnumerator DeathAnimationAndDestroyWorm() {
            yield return new WaitForSeconds(0.5f);
            Instantiate(wormGrave, transform.position, Quaternion.identity);
            ReplayManager.nextRoundUpdateWormsEvent -= UpdateWorm;
            Destroy(gameObject); 
        }

        void Update() {
            if (isMoving) {
                float step = moveSpeed * Time.deltaTime;

                transform.position = Vector3.MoveTowards(transform.position, target, step);

                if (Vector3.Distance(transform.position, target) < 0.001f) {
                    isMoving = false;
                    gameObject.transform.position = target;
                }
            }
        }

        private void UpdateWormPosition(Vector2 position) {
            isMoving = true;
            target = new Vector3(position.x, 0f, position.y);
        }
    }
}