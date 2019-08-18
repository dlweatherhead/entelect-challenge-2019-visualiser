using System;
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
                    handleShootEvent(visualiserEvent);
                }
                else if (visualiserEvent.Type.Equals("banana")) {
                    handleBananaBombEvent(visualiserEvent);
                }
                else if (visualiserEvent.Type.Equals("snowball")) {
                    handleSnowBallEvent(visualiserEvent);
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

        private void handleShootEvent(VisualiserEvent visualiserEvent) {
            var start = visualiserEvent.PositionStart;
            var end = visualiserEvent.PositionEnd;

            var startPos = new Vector3(start.x, 0f, start.y);
            var endPos = new Vector3(end.x, 0f, end.y);

            drawLine(startPos, endPos, shootMaterial);

            Instantiate(shootingHitAnimation, endPos, Quaternion.identity);
        }

        private void handleBananaBombEvent(VisualiserEvent visualiserEvent) {
            var start = visualiserEvent.PositionStart;
            var end = visualiserEvent.PositionEnd;

            var startPos = new Vector3(start.x, 0f, start.y);
            var endPos = new Vector3(end.x, 0f, end.y);

            for (int x = -bananaBombRadius; x < bananaBombRadius; x++) {
                for (int z = -bananaBombRadius; z < bananaBombRadius; z++) {
                    if (x == 0 && z == 0) {
                        continue;
                    }

                    var explosionPos = new Vector3(endPos.x + x, 0f, endPos.z + z);
                    var a2 = Instantiate(bananaBombAnimationRadius, explosionPos, Quaternion.identity);
                    Destroy(a2, 1f);
                }
            }

            drawLine(startPos, endPos, shootMaterial);

            var a1 = Instantiate(bananaBombAnimationCenter, endPos, Quaternion.identity);
            Destroy(a1, 1f);
        }

        private void handleSnowBallEvent(VisualiserEvent visualiserEvent) {
            var start = visualiserEvent.PositionStart;
            var end = visualiserEvent.PositionEnd;

            var startPos = new Vector3(start.x, 0f, start.y);
            var endPos = new Vector3(end.x, 0f, end.y);

            drawLine(startPos, endPos, shootMaterial);

            foreach (var affectedCell in visualiserEvent.AffectedCells) {
                var cell = new Vector3(affectedCell.X, 0f, affectedCell.Y);
                var a = Instantiate(snowBallAnimation, cell, Quaternion.identity);
                
                Destroy(a, 1f);
            }
        }

        private void handleMoveEvent(VisualiserEvent visualiserEvent) {
            var start = visualiserEvent.PositionStart;
            var end = visualiserEvent.PositionEnd;
            drawLine(
                new Vector3(start.x, 0f, start.y),
                new Vector3(end.x, 0f, end.y),
                moveMaterial);
        }

        private void handleDigEvent(VisualiserEvent visualiserEvent) {
            var endPos = visualiserEvent.PositionEnd;

            var o = new GameObject();
            var lineRenderer = o.AddComponent<MeshRenderer>();
            lineRenderer.material = digMaterial;

            o.transform.position = new Vector3(endPos.x, 0f, endPos.y);

            Destroy(o, 1f);
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
                    Destroy(g, 1f);
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

            Destroy(o, 1f);
        }
    }
}