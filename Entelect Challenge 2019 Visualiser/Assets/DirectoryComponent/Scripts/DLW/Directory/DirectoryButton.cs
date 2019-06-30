using UnityEngine;
using UnityEngine.UI;

namespace DLW.Directory
{
	public class DirectoryButton : MonoBehaviour {

		public Button buttonComponent;
		public Text title;
		
        private string fullPath;
        private DirectorySelector directorySelector;

        public void Setup(string title, string fullPath, DirectorySelector directorySelector) {
			this.title.text = title;
			this.fullPath = fullPath;
			this.directorySelector = directorySelector;
			
			buttonComponent.onClick.AddListener (HandleClick);
		}

		public void HandleClick() {
			directorySelector.OnDirectoryButtonClicked (fullPath);

			GameObject.FindGameObjectWithTag("DirectoryScrollView").SetActive(false);
		}
	}
}
