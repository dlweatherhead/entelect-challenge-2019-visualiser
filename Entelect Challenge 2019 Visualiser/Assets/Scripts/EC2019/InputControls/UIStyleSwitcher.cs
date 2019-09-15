using UnityEngine;

namespace EC2019.InputControls {
    public class UIStyleSwitcher : MonoBehaviour {
        public GameObject singleScreenCanvas;
        public GameObject dualScreenCanvas;
    
        void Update() {
            if (Input.GetKeyDown(KeyCode.Alpha1)) {
                singleScreenCanvas.SetActive(true);
                dualScreenCanvas.SetActive(false);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2)) {
                singleScreenCanvas.SetActive(false);
                dualScreenCanvas.SetActive(true);
            }
        }
    }
}
