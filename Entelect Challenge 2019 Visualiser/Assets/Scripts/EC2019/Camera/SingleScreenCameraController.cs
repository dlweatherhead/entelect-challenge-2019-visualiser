using System;
using EC2019.Utility;
using UnityEngine;
using UnityEngine.Assertions.Comparers;

namespace EC2019.Camera {
    public class SingleScreenCameraController : MonoBehaviour {
        public float speed = 0.3F;
        public UnityEngine.Camera myCamera;

        private float startTime;
        private float sizeStartTime;
        private float sizeEndMarker;

        private Vector3 moveEndMarker;

        public float maxCameraZoom;
        public float minCameraZoom = 14f;
        public float cameraSensitivity;
        
        public void Start() {
            moveEndMarker = transform.position;
            sizeEndMarker = myCamera.orthographicSize;
            maxCameraZoom = PlayerPrefs.GetFloat(Constants.PlayerPrefKeys.MaxCameraZoom, 7f);
            cameraSensitivity = PlayerPrefs.GetFloat(Constants.PlayerPrefKeys.CameraSensitivity, 0.6f);
        }

        public void Update() {
            var timeIncrement = (Time.time - startTime) * speed;
            var sizeStartMarker = myCamera.orthographicSize;
            var moveStartMarker = transform.position;
            myCamera.orthographicSize = Mathf.Lerp(sizeStartMarker, sizeEndMarker, timeIncrement);
            transform.position = Vector3.Lerp(moveStartMarker, moveEndMarker, timeIncrement);
        }

        public void UpdateSize() {
            var midPoint = Vector3.zero;
            var worms = GameObject.FindGameObjectsWithTag(Constants.Tags.Worm);

            if (worms == null || worms.Length <= 0) return;

            foreach (var worm in worms) {
                midPoint += worm.transform.position;
            }

            midPoint /= worms.Length;

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

            var delta_x = x_right - x_left;
            var delta_z = z_high - z_low;
            var maxDelta = delta_x > delta_z ? delta_x : delta_z;
            var newCameraSize = maxDelta * cameraSensitivity;

            startTime = Time.time;
            sizeEndMarker = Mathf.Clamp(newCameraSize, maxCameraZoom, minCameraZoom);
            moveEndMarker = midPoint;
        }
    }
}