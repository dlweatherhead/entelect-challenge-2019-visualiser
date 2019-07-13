using UnityEngine;

namespace EC2019.Camera
{
    public class CameraController : MonoBehaviour {
        
        public Vector3 endMarker;
        public float speed = 0.5F;
        
        private float startTime;

        void Start()
        {
            startTime = Time.time;
        }
        
        public void Update() {
            var timeIncrement = (Time.time - startTime) * speed;
            var startMarker = transform.position;
            transform.position = Vector3.Lerp(startMarker, endMarker, timeIncrement);
        }

        public void UpdatePosition(int playerACurrentWormId, int playerBCurrentWormId)
        {
            GameObject[] worms = GameObject.FindGameObjectsWithTag("Worm");

            Vector3 wormA = Vector3.zero;
            Vector3 wormB = Vector3.zero;

            if (worms != null && worms.Length > 0)
            {
                foreach (var worm in worms)
                {
                    if (worm != null)
                    {
                        var wc = worm.GetComponent<WormComponent>();
                        if (wc.playerId == 1 && wc.id == playerACurrentWormId)
                        {
                            wormA = worm.transform.position;
                        }

                        if (wc.playerId == 2 && wc.id == playerBCurrentWormId)
                        {
                            wormB = worm.transform.position;
                        }
                    }
                }
                
                var midPoint = (wormA + wormB) / 2;
                var y = gameObject.transform.position.y;
            
                endMarker = new Vector3(midPoint.x, y, midPoint.z);
            }
        }
    }
}