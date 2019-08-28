using UnityEngine;

namespace EC2019 {
    public class ThrowAnimation : MonoBehaviour {
        public Vector3 destination;

        private float speed = 1f;

        void Start() {
            speed = Vector3.Distance(transform.position, destination);
        }
        
        void Update() {
            var step = 2 * speed * Time.deltaTime;
                
            transform.position = Vector3.MoveTowards(transform.position, destination, step);
        
            if (Vector3.Distance(transform.position, destination) < 0.001f) {
                Destroy(gameObject);
            }
        }
    }
}
