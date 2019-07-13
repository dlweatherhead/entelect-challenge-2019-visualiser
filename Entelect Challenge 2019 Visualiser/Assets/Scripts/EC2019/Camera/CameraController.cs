using System.Collections.Generic;
using EC2019.Entity;
using UnityEngine;

namespace EC2019.Camera
{
    public class CameraController : MonoBehaviour
    {

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
            }

            var midPoint = (wormA + wormB) / 2;
            var y = gameObject.transform.position.y;
            gameObject.transform.position = new Vector3(midPoint.x, y, midPoint.z);
        }
    }
}