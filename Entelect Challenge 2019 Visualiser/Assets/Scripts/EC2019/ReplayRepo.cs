using System.Collections.Generic;
using EC2019;
using EC2019.Entity;
using UnityEngine;

public class ReplayRepo : MonoBehaviour {
    private List<GlobalState> rounds;

    private void OnEnable() {
        ReplayLoader.roundsFinishedLoadingEvent += RoundsFinishedLoading;
    }

    private void OnDisable() {
        ReplayLoader.roundsFinishedLoadingEvent -= RoundsFinishedLoading;
    }

    private void RoundsFinishedLoading(List<GlobalState> loadedRounds) {
        rounds = loadedRounds;
    }

    public GlobalState GetRound(int round) {
        return rounds[round];
    }

    public int totalRounds() {
        return rounds.Count;
    }
}