using System;
using EC2019;
using EC2019.Entity;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour {

    public WormUIManager playerA_worm1;
    public WormUIManager playerA_worm2;
    public WormUIManager playerA_worm3;

    public WormUIManager playerB_worm1;
    public WormUIManager playerB_worm2;
    public WormUIManager playerB_worm3;

    public void Awake() {
        ReplayManager.nextRoundUpdateUIEvent += UpdateUI;
    }

    void UpdateUI(Player playerA, Player playerB) {
        playerA_worm1.UpdateUI(playerA.Worms[0]);
        playerA_worm2.UpdateUI(playerA.Worms[1]);
        playerA_worm3.UpdateUI(playerA.Worms[2]);
        playerB_worm1.UpdateUI(playerB.Worms[0]);
        playerB_worm2.UpdateUI(playerB.Worms[1]);
        playerB_worm3.UpdateUI(playerB.Worms[2]);
    }
}