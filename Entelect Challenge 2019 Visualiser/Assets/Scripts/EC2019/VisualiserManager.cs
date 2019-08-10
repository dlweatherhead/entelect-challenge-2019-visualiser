using System.Collections.Generic;
using EC2019.Entity;
using UnityEngine;

namespace EC2019 {
    public class VisualiserManager : MonoBehaviour {

        public Material shootMaterial;
        public Material moveMaterial;
        public Material digMaterial;
        public Material selectMaterial;

        public void processVisualisations(List<VisualiserEvent> visualiserEvents) {
            foreach (var visualiserEvent in visualiserEvents) {
                if (visualiserEvent.Type.Equals("shoot")) {
                    handleShootEvent(visualiserEvent);
                } else if (visualiserEvent.Type.Equals("move")) {
                    handleMoveEvent(visualiserEvent);
                } else if (visualiserEvent.Type.Equals("dig")) {
                    handleDigEvent(visualiserEvent);
                } else if (visualiserEvent.Type.Equals("select")) {
                    handleSelectEvent(visualiserEvent);
                } 
            }
        }

        private void handleShootEvent(VisualiserEvent visualiserEvent) {
            var start = visualiserEvent.PositionStart;
            var end = visualiserEvent.PositionEnd;
            drawLine(
                new Vector3(start.x, 0.5f, start.y), 
                new Vector3(end.x, 0.5f, end.y),
                shootMaterial);
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

        private void drawLine(Vector3 start, Vector3 end, Material material) {
            var o = new GameObject();
            var lineRenderer = o.AddComponent<LineRenderer>();
            lineRenderer.material = material;
            lineRenderer.widthMultiplier = 0.2f;
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, start);
            lineRenderer.SetPosition(1, end);

            Destroy(o, 1f);
        }
    }
}
