using System.Collections.Generic;
using System.IO;
using System.Linq;
using DLW.Directory;
using EC2019.Entity;
using UnityEngine;
using EC2019.Utility;

namespace EC2019 {
    public class ReplayLoader : MonoBehaviour, IDirectorySelectorAction {
        
        public delegate void RoundsFinishedLoading(List<Round> rounds);
        public static event RoundsFinishedLoading roundsFinishedLoadingEvent;

        public void OnSelected(string absoluteDirectory) {
            var roundsList = Directory.GetDirectories(absoluteDirectory);

            var rounds = (from round in roundsList 
                select Directory.GetDirectories(round)[0] into playerA 
                select playerA + "/JsonMap.json" into jsonMap 
                select new JsonFileParser<Round>(jsonMap).GetSerializedData()).ToList();

            roundsFinishedLoadingEvent?.Invoke(rounds);
        }
    }
}