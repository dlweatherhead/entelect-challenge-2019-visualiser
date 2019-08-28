using System;
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

        public Material moveMaterial;
        public GameObject moveAnimation;

        public Material digMaterial;
        public GameObject digAnimation;

        public Material selectMaterial;
        public GameObject selectAnimation;
        
        public GameObject nothingAnimation;

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
            var start = visualiserEvent.PositionStart;
            var end = visualiserEvent.PositionEnd;

            var startPos = new Vector3(start.x, 0f, start.y);
            var endPos = new Vector3(end.x, 0f, end.y);

            if (visualiserEvent.WormCommanded.PlayerId == Constants.PlayerA.Number) {
                var o = Instantiate(bombAnimationA, startPos, Quaternion.identity);
                o.GetComponent<ThrowAnimation>().destination = endPos;
            } else if (visualiserEvent.WormCommanded.PlayerId == Constants.PlayerB.Number) {
                var o = Instantiate(bombAnimationB, startPos, Quaternion.identity);
                o.GetComponent<ThrowAnimation>().destination = endPos;
            }
            
            yield return new WaitForSeconds(ReplayManager.globalTimePerRound/2f);

            Instantiate(shootingHitAnimation, endPos, Quaternion.identity);
        }

        private IEnumerator handleBananaBombEvent(VisualiserEvent visualiserEvent) {
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

                    var explosionPos = new Vector3(endPos.x + x, 0f, endPos.z + z);
                    var a2 = Instantiate(bananaBombAnimationRadius, explosionPos, Quaternion.identity);
                    Destroy(a2, ReplayManager.globalTimePerRound);
                }
            }

            var a1 = Instantiate(bananaBombAnimationCenter, endPos, Quaternion.identity);
            Destroy(a1, ReplayManager.globalTimePerRound);
        }

        private IEnumerator handleSnowBallEvent(VisualiserEvent visualiserEvent) {
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
        }

        private void handleMoveEvent(VisualiserEvent visualiserEvent) {
            // No-op
            // Todo - Add animation event or tiles indicating move path
        }

        private void handleDigEvent(VisualiserEvent visualiserEvent) {
            var endPos = visualiserEvent.PositionEnd;

            var o = new GameObject();
            var lineRenderer = o.AddComponent<MeshRenderer>();
            lineRenderer.material = digMaterial;

            o.transform.position = new Vector3(endPos.x, 0f, endPos.y);

            Destroy(o, ReplayManager.globalTimePerRound);
        }

        private void handleSelectEvent(VisualiserEvent visualiserEvent) {
            Debug.Log("Worm selected");
        }

        private void handleNothingEvent(VisualiserEvent visualiserEvent) {
            var wormCommanded = visualiserEvent.WormCommanded;

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
            
            var updatedStartPos = new Vector3(start.x, 0.5f, start.z);
            var updatedEndPos = new Vector3(end.x, 0.5f, end.z);
            
            var o = new GameObject();
            var lineRenderer = o.AddComponent<LineRenderer>();
            lineRenderer.material = material;
            lineRenderer.widthMultiplier = 0.2f;
            lineRenderer.positionCount = 2;
            lineRenderer.sortingLayerName = "Lines";
            lineRenderer.SetPosition(0, updatedStartPos);
            lineRenderer.SetPosition(1, updatedEndPos);

            Destroy(o, ReplayManager.globalTimePerRound);
        }
    }
}