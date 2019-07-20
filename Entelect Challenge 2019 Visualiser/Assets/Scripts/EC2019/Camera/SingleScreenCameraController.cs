using UnityEngine;
using UnityEngine.Assertions.Comparers;

namespace EC2019.Camera {
    public class SingleScreenCameraController : MonoBehaviour {
        public float speed = 0.3F;
        public UnityEngine.Camera myCamera;

        private float startTime;
        private float sizeStartTime;
        private float sizeEndMarker;

        public void Update() {
            var timeIncrement = (Time.time - startTime) * speed;
            var sizeStartMarker = myCamera.orthographicSize;
            myCamera.orthographicSize = Mathf.Lerp(sizeStartMarker, sizeEndMarker, timeIncrement);
        }

        public void UpdateSize() {
            var midPoint = Vector3.zero;
            var worms = GameObject.FindGameObjectsWithTag("Worm");

            if (worms == null || worms.Length <= 0) return;

            // Calc midpoint
            foreach (var worm in worms) {
                midPoint += worm.transform.position;
            }

            midPoint /= worms.Length;

            // Get max x left of midpoint
            // Get max x right of midpoint
            // Get max z above midpoint
            // Get max z below midpoint
            var x_left = midPoint.x;
            var x_right = midPoint.x;
            var z_low = midPoint.z;
            var z_high = midPoint.z;

            foreach (var worm in worms) {
                if (worm.transform.position.x < x_left) {
                    x_left = worm.transform.position.x;
                }

                if (worm.transform.position.x > x_right) {
                    x_right = worm.transform.position.x;
                }

                if (worm.transform.position.z < z_low) {
                    z_low = worm.transform.position.z;
                }

                if (worm.transform.position.z > z_high) {
                    z_low = worm.transform.position.z;
                }
            }

            // Get delta x
            // Get delta z
            var delta_x = x_right - x_left;
            var delta_z = z_high - z_low;

            // Determine max delta
            var maxDelta = delta_x > delta_z ? delta_x : delta_z;

            var newCameraSize = maxDelta < 1f ? myCamera.orthographicSize : maxDelta * 0.5f;

            Debug.Log("Updating Size: " +
                      "midPoint" + midPoint +
                      ", xL=" + x_left +
                      ", xR=" + x_right +
                      ", zH=" + z_high +
                      ", zL=" + z_low +
                      ", dX=" + delta_x +
                      ", dZ=" + delta_z +
                      ", mD=" + maxDelta +
                      ", size=" + newCameraSize);

            // get size equation by multiplying with 0.5 [sin(30)] from isometric angle
            startTime = Time.time;
            sizeEndMarker = newCameraSize;
        }
    }
}