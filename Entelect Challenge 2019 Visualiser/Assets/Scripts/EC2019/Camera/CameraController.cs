using System.Collections.Generic;
using EC2019.Entity;
using UnityEngine;

namespace EC2019.Camera {
    public class CameraController : MonoBehaviour {

        private GameObject[] worms;

        void Update() {
            
            worms = GameObject.FindGameObjectsWithTag("Worm");
            
            if (worms != null && worms.Length > 0) {
                SetPositionFromWormsCenter();
            }
        }

        private void SetPositionFromWormsCenter() {
            var totalX = 0f;
            var totalY = 0f;
            foreach(var worm in worms)
            {
                var position = worm.transform.position;
                totalX += position.x;
                totalY += position.y;
            }
            var centerX = totalX / worms.Length;
            var centerY = totalY / worms.Length;

            var o = gameObject;
            o.transform.position = new Vector3(centerX, centerY, o.transform.position.z);
        }
    }
}