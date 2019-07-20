using UnityEngine;
using UnityEngine.Assertions.Comparers;

namespace EC2019.Camera {
    public class DualScreenCameraController : MonoBehaviour {
        public Vector3 endMarker;
        public float speed = 0.3F;

        public GameObject playerACamera;
        public GameObject playerBCamera;

        private float startTime;
        private float sizeStartTime;

        private float sizeEndMarker;

//        public void Update() {
//            var timeIncrement = (Time.time - startTime) * speed;
//            var startMarker = transform.position;
//            transform.position = Vector3.Lerp(startMarker, endMarker, timeIncrement);
//        }

        public void UpdatePositions(int playerACurrentWormId, int playerBCurrentWormId) {
            GameObject[] worms = GameObject.FindGameObjectsWithTag("Worm");

            Vector3 wormA = Vector3.zero;
            Vector3 wormB = Vector3.zero;

            if (worms != null && worms.Length > 0) {
                foreach (var worm in worms) {
                    if (worm != null) {
                        var wc = worm.GetComponent<WormComponent>();
                        if (wc.playerId == 1 && wc.id == playerACurrentWormId) {
                            wormA = worm.transform.position;
                        }

                        if (wc.playerId == 2 && wc.id == playerBCurrentWormId) {
                            wormB = worm.transform.position;
                        }
                    }
                }

                playerACamera.transform.position = wormA;
                playerBCamera.transform.position = wormB;
            }
        }
    }
}