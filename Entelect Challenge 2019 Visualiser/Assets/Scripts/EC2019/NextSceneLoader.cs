using System.Collections.Generic;
using DLW.Directory;
using EC2019.Entity;
using EC2019.Utility;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EC2019
{
    public class NextSceneLoader : MonoBehaviour, IDirectorySelectorAction
    {
        public string sceneName;

        public void OnSelected(string absoluteDirectory)
        {
            PlayerPrefs.SetString(Constants.PlayerPrefKeys.SelectedReplay, absoluteDirectory);
            SceneManager.LoadSceneAsync(sceneName);
        }
    }
}