using System;
using EC2019;
using EC2019.Entity;
using EC2019.Utility;
using UnityEngine;
using TMPro;

public class WormUIManager : MonoBehaviour {

    public WormUIComponent playerA_worm1;
    public WormUIComponent playerA_worm2;
    public WormUIComponent playerA_worm3;

    public WormUIComponent playerB_worm1;
    public WormUIComponent playerB_worm2;
    public WormUIComponent playerB_worm3;

    public void Awake() {
        ReplayManager.nextRoundUpdateUIEvent += UpdateUI;
    }

    void UpdateUI(GlobalState round) {
        var playerA = round.Opponents[0];
        var playerB = round.Opponents[1];
        
        playerA_worm1.UpdateUI(playerA.Worms[0], Constants.PlayerA.Number);
        playerA_worm2.UpdateUI(playerA.Worms[1], Constants.PlayerA.Number);
        playerA_worm3.UpdateUI(playerA.Worms[2], Constants.PlayerA.Number);
        playerB_worm1.UpdateUI(playerB.Worms[0], Constants.PlayerB.Number);
        playerB_worm2.UpdateUI(playerB.Worms[1], Constants.PlayerB.Number);
        playerB_worm3.UpdateUI(playerB.Worms[2], Constants.PlayerB.Number);
    }
}