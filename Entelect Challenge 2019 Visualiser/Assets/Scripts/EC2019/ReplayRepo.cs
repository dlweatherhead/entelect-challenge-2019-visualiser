using System.Collections;
using System.Collections.Generic;
using EC2019;
using EC2019.Entity;
using UnityEngine;

public class ReplayRepo : MonoBehaviour
{
    Dictionary<string, List<Round>> playerRounds;

    void OnEnable() {
        ReplayLoader.roundsFinishedLoadingEvent += RoundsFinishedLoading;
    }

    void OnDisable()
    {
        ReplayLoader.roundsFinishedLoadingEvent -= RoundsFinishedLoading;
    }
    
    void RoundsFinishedLoading(Dictionary<string, List<Round>> loadedRounds)
    {
        playerRounds = loadedRounds;
    }

    public List<Round> GetPlayerARounds()
    {
        return playerRounds["playerA"];
    }

    public List<Round> GetPlayerBRounds()
    {
        return playerRounds["playerB"];
    }
}
