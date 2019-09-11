using System.Collections;
using System.Collections.Generic;
using EC2019.Entity;
using EC2019.Utility;
using UnityEngine;

namespace EC2019 {
    public class VisualiserManager : MonoBehaviour {
        public Material shootMaterial;
        public GameObject shootingHitAnimation;

        public int bananaBombRadius = 3;
        public GameObject bananaBombAnimationCenter;
        public GameObject bananaBombAnimationRadius;
        
        public GameObject snowBallAnimation;

        public GameObject bombAnimationA;
        public GameObject bombAnimationB;
        public GameObject snowballAnimationA;
        public GameObject snowballAnimationB;
        public GameObject bananaAnimationA;
        public GameObject bananaAnimationB;
        
        public GameObject moveAnimation;
        public GameObject digAnimation;
        public GameObject selectAnimation;
        public GameObject nothingAnimation;

        public RandomClipPlayer moveSounds;
        public RandomClipPlayer digSounds;
        public RandomClipPlayer nothingSounds;
        public RandomClipPlayer selectSounds;
        public RandomClipPlayer throwSounds;
        public RandomClipPlayer wormOuchSounds;
        public RandomClipPlayer wormQuipSounds;

        public Material materialPlayerAShoot;
        public Material materialPlayerBShoot;

        public void processVisualisations(List<VisualiserEvent> visualiserEvents) {
            foreach (var visualiserEvent in visualiserEvents) {
                if (visualiserEvent.Type.Equals("shoot")) {
                    StartCoroutine(handleShootEvent(visualiserEvent));
                }
                else if (visualiserEvent.Type.Equals("banana")) {
                    StartCoroutine(handleBananaBombEvent(visualiserEvent));
                }
                else if (visualiserEvent.Type.Equals("snowball")) {
                    StartCoroutine(handleSnowBallEvent(visualiserEvent));
                }
                else if (visualiserEvent.Type.Equals("move")) {
                    handleMoveEvent(visualiserEvent);
                }
                else if (visualiserEvent.Type.Equals("dig")) {
                    handleDigEvent(visualiserEvent);
                }
                else if (visualiserEvent.Type.Equals("select")) {
                    handleSelectEvent(visualiserEvent);
                } 
                else if (visualiserEvent.Type.Equals("nothing")) {
                    handleNothingEvent(visualiserEvent);
                }
                else {
                    Debug.Log("Unexpected event: " + visualiserEvent.Type);
                }
            }
        }

        private IEnumerator handleShootEvent(VisualiserEvent visualiserEvent) {
            throwSounds.PlayRandomSound(visualiserEvent.WormCommanded.PlayerId);
            
            var start = visualiserEvent.PositionStart;
            var end = visualiserEvent.PositionEnd;

            var startPos = new Vector3(start.x, 0.5f, start.y);
            var endPos = new Vector3(end.x, 0.5f, end.y);

            yield return new WaitForSeconds(ReplayManager.globalTimePerRound/2f);

            Instantiate(shootingHitAnimation, endPos, Quaternion.identity);
            if (visualiserEvent.WormCommanded.PlayerId == Constants.PlayerA.Number) {
                drawLine(startPos, endPos, materialPlayerAShoot);
            } else if (visualiserEvent.WormCommanded.PlayerId == Constants.PlayerB.Number) {
                drawLine(startPos, endPos, materialPlayerBShoot);
            }

            if (visualiserEvent.WormCommanded.PlayerId == Constants.PlayerA.Number) {
                wormOuchSounds.PlayRandomSound(Constants.PlayerB.Number);
            }
            else {
                wormOuchSounds.PlayRandomSound(Constants.PlayerA.Number);
            }
        }

        private IEnumerator handleBananaBombEvent(VisualiserEvent visualiserEvent) {
            throwSounds.PlayRandomSound(visualiserEvent.WormCommanded.PlayerId);
            
            var start = visualiserEvent.PositionStart;
            var end = visualiserEvent.PositionEnd;

            var startPos = new Vector3(start.x, 0f, start.y);
            var endPos = new Vector3(end.x, 0f, end.y);
            
            if (visualiserEvent.WormCommanded.PlayerId == Constants.PlayerA.Number) {
                var o = Instantiate(bananaAnimationA, startPos, Quaternion.identity);
                o.GetComponent<ThrowAnimation>().destination = endPos;
            } else if (visualiserEvent.WormCommanded.PlayerId == Constants.PlayerB.Number) {
                var o = Instantiate(bananaAnimationB, startPos, Quaternion.identity);
                o.GetComponent<ThrowAnimation>().destination = endPos;
            }
            
            yield return new WaitForSeconds(ReplayManager.globalTimePerRound/2f);

            for (int x = -bananaBombRadius; x < bananaBombRadius; x++) {
                for (int z = -bananaBombRadius; z < bananaBombRadius; z++) {
                    if (x == 0 && z == 0) {
                        continue;
                    }

                    if (2 >= Mathf.Abs(x) && z == 0 ||
                        2 >= Mathf.Abs(z) && x == 0 ||
                        1 == Mathf.Abs(x) && 1 == Mathf.Abs(z)) {
                        var explosionPos = new Vector3(endPos.x + x, 0f, endPos.z + z);
                        var a2 = Instantiate(bananaBombAnimationRadius, explosionPos, Quaternion.identity);
                        a2.GetComponent<AudioSource>().volume = 0f;
                        Destroy(a2, ReplayManager.globalTimePerRound);                        
                    }
                }
            }

            var a1 = Instantiate(bananaBombAnimationCenter, endPos, Quaternion.identity);
            Destroy(a1, ReplayManager.globalTimePerRound);
            
            if (visualiserEvent.WormCommanded.PlayerId == Constants.PlayerA.Number) {
                wormOuchSounds.PlayRandomSound(Constants.PlayerB.Number);
            }
            else {
                wormOuchSounds.PlayRandomSound(Constants.PlayerA.Number);
            }
        }

        private IEnumerator handleSnowBallEvent(VisualiserEvent visualiserEvent) {
            throwSounds.PlayRandomSound(visualiserEvent.WormCommanded.PlayerId);
            
            var start = visualiserEvent.PositionStart;
            var end = visualiserEvent.PositionEnd;

            var startPos = new Vector3(start.x, 0f, start.y);
            var endPos = new Vector3(end.x, 0f, end.y);
            
            if (visualiserEvent.WormCommanded.PlayerId == Constants.PlayerA.Number) {
                var o = Instantiate(snowballAnimationA, startPos, Quaternion.identity);
                o.GetComponent<ThrowAnimation>().destination = endPos;
            } else if (visualiserEvent.WormCommanded.PlayerId == Constants.PlayerB.Number) {
                var o = Instantiate(snowballAnimationB, startPos, Quaternion.identity);
                o.GetComponent<ThrowAnimation>().destination = endPos;
            }
            
            yield return new WaitForSeconds(ReplayManager.globalTimePerRound/2f);

            foreach (var affectedCell in visualiserEvent.AffectedCells) {
                var cell = new Vector3(affectedCell.X, 0f, affectedCell.Y);
                var a = Instantiate(snowBallAnimation, cell, Quaternion.identity);
                
                Destroy(a, ReplayManager.globalTimePerRound);
            }
            
            if (visualiserEvent.WormCommanded.PlayerId == Constants.PlayerA.Number) {
                wormOuchSounds.PlayRandomSound(Constants.PlayerB.Number);
            }
            else {
                wormOuchSounds.PlayRandomSound(Constants.PlayerA.Number);
            }
        }

        private void handleMoveEvent(VisualiserEvent visualiserEvent) {
            moveSounds.PlayRandomSound(visualiserEvent.WormCommanded.PlayerId);
        }

        private void handleDigEvent(VisualiserEvent visualiserEvent) {
            digSounds.PlayRandomSound(visualiserEvent.WormCommanded.PlayerId);
            
            var end = visualiserEvent.PositionEnd;
            var endPos = new Vector3(end.x, 0f, end.y);

            var o = Instantiate(digAnimation, endPos, Quaternion.identity);

            Destroy(o, ReplayManager.globalTimePerRound);
        }

        private void handleSelectEvent(VisualiserEvent visualiserEvent) {
            selectSounds.PlayRandomSound(visualiserEvent.WormCommanded.PlayerId);

            var wormCommanded = visualiserEvent.WormCommanded;
            var worms = GameObject.FindGameObjectsWithTag(Constants.Tags.Worm);

            foreach (var worm in worms) {
                var wormComponent = worm.GetComponent<WormComponent>();
                if (wormComponent.playerId == wormCommanded.PlayerId &&
                    wormComponent.id == wormCommanded.Id) {
                    var o = Instantiate(selectAnimation, wormComponent.transform.position, Quaternion.identity);
                    Destroy(o, ReplayManager.globalTimePerRound);
                    break;
                }
            }
        }

        private void handleNothingEvent(VisualiserEvent visualiserEvent) {
            var wormCommanded = visualiserEvent.WormCommanded;
            
            wormQuipSounds.PlayRandomSound(wormCommanded.PlayerId);

            var worms = GameObject.FindGameObjectsWithTag(Constants.Tags.Worm);
            
            foreach (var o in worms) {
                var worm = o.GetComponentInChildren<WormComponent>();

                if (worm.playerId == wormCommanded.PlayerId && worm.id == wormCommanded.Id) {
                    var g = Instantiate(nothingAnimation, worm.transform.position, Quaternion.identity);
                    Destroy(g, ReplayManager.globalTimePerRound);
                }
            }
        }
        
        private void drawLine(Vector3 start, Vector3 end, Material material) {
            var o = new GameObject();
            var lineRenderer = o.AddComponent<LineRenderer>();
            lineRenderer.material = material;
            lineRenderer.widthMultiplier = 0.22f;
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, start);
            lineRenderer.SetPosition(1, end);

            Destroy(o, 0.4f);
        }
    }
}