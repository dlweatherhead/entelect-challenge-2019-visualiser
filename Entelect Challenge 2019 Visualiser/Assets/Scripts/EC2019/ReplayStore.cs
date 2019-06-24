using System.Collections.Generic;
using System.IO;
using DLW.Directory;
using EC2019.Entity;
using UnityEngine;
using EC2019.Utility;

namespace EC2019 {
    public class ReplayStore : MonoBehaviour, IDirectorySelectorAction {
        private List<Round> rounds;

        void Start() {
            rounds = new List<Round>();
        }

        public void OnSelected(string absoluteDirectory) {
            var roundsList = Directory.GetDirectories(absoluteDirectory);

            foreach (var round in roundsList) {
                var playerA = Directory.GetDirectories(round)[0];
                var jsonMap = playerA + "/JsonMap.json";

                rounds.Add(new JsonFileParser<Round>(jsonMap).GetSerializedData());
            }
        }
    }
}