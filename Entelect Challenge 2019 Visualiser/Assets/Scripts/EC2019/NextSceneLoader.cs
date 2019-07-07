using System.Collections.Generic;
using DLW.Directory;
using EC2019.Entity;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EC2019
{
    public class NextSceneLoader : MonoBehaviour, IDirectorySelectorAction
    {
        public string sceneName;

        public void OnSelected(string absoluteDirectory)
        {
            PlayerPrefs.SetString("replayMatch", absoluteDirectory);
            SceneManager.LoadSceneAsync(sceneName);
        }
    }
}