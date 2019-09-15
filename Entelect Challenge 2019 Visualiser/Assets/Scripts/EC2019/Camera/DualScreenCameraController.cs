using EC2019.Utility;
using UnityEngine;
using UnityEngine.Assertions.Comparers;

namespace EC2019.Camera {
    public class DualScreenCameraController : MonoBehaviour {
        public GameObject playerACameraHolder;
        public GameObject playerBCameraHolder;

        public Vector3 endMarkerA;
        public Vector3 endMarkerB;
        public float speed = 0.3F;
        private float startTime;

        public void Update() {
            var timeIncrement = (Time.time - startTime) * speed;
            var startMarkerA = playerACameraHolder.transform.position;
            var startMarkerB = playerBCameraHolder.transform.position;
            playerACameraHolder.transform.position = Vector3.Lerp(startMarkerA, endMarkerA, timeIncrement);
            playerBCameraHolder.transform.position = Vector3.Lerp(startMarkerB, endMarkerB, timeIncrement);
        }

        public void UpdatePositions(int playerACurrentWormId, int playerBCurrentWormId) {
            GameObject[] worms = GameObject.FindGameObjectsWithTag(Constants.Tags.Worm);

            Vector3 destinationA = playerACameraHolder.transform.position;
            Vector3 destinationB = playerBCameraHolder.transform.position;

            if (worms != null && worms.Length > 0) {
                foreach (var worm in worms) {
                    var wc = worm.GetComponent<WormComponent>();
                    if (wc.playerId == 1 && wc.id == playerACurrentWormId) {
                        destinationA = worm.transform.position;
                    }

                    if (wc.playerId == 2 && wc.id == playerBCurrentWormId) {
                        destinationB = worm.transform.position;
                    }
                }

                endMarkerA = destinationA;
                endMarkerB = destinationB;
                startTime = Time.time;
            }
        }
    }
}