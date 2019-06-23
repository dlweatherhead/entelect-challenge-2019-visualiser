using System.Collections.Generic;
using System.IO;
using DLW.Directory;
using EC2019.Entity;
using UnityEngine;

namespace EC2019 {
    public class ReplayStore : MonoBehaviour, IDirectorySelectorAction {
        private List<Round> rounds;

        public void OnSelected(string absoluteDirectory) {
            var roundsList = Directory.GetDirectories(absoluteDirectory);

            foreach (var round in roundsList) Debug.Log(round);
        }
    }
}