using System.IO;
using UnityEngine;

namespace DLW.Directory {
    public class DirectorySelector : MonoBehaviour {
        public GameObject directorySelectorAction;
        public string directory = "/Matches";

        public GameObject contentListParent;
        public GameObject directoryButton;

        private static string ApplicationPath {
            get {
                var dataPath = Application.dataPath;
                switch (Application.platform) {
                    case RuntimePlatform.WindowsPlayer:
                        return dataPath + "/../";
                    case RuntimePlatform.OSXPlayer:
                        return dataPath + "/../../";
                    case RuntimePlatform.LinuxPlayer:
                        return dataPath + "/../";
                    default:
                        return dataPath;
                }
            }
        }

        void Start() {
            var replays = System.IO.Directory.GetDirectories(ApplicationPath + directory);

            for (var i = 0; i < replays.Length; i++) {
                var fullPath = replays[i];
                var folderName = new DirectoryInfo(fullPath).Name;

                var b = Instantiate(directoryButton, contentListParent.transform, true);
                b.GetComponentInChildren<DirectoryButton>().Setup(folderName, fullPath, this);
            }
        }

        public void OnDirectoryButtonClicked(string absoluteDirectory) {
            directorySelectorAction.GetComponent<IDirectorySelectorAction>().OnSelected(absoluteDirectory);
        }
    }
}