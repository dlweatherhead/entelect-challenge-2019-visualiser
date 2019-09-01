using System.Collections;
using System.Collections.Generic;
using EC2019.Utility;
using TMPro;
using UnityEngine;

public class EndGameSceneManager : MonoBehaviour {

    public TMP_Text playerName;
    public TMP_Text playerScore;

    public GameObject[] playerAGraphics;
    public GameObject[] playerBGraphics;
    
    void Start() {
        var winningPlayer = PlayerPrefs.GetInt(Constants.PlayerPrefKeys.WinningPlayer);
        var winningName = PlayerPrefs.GetString(Constants.PlayerPrefKeys.WinningName);
        var winningScore = PlayerPrefs.GetInt(Constants.PlayerPrefKeys.WinningScore);

        playerName.text = winningName;
        playerScore.text = winningScore.ToString();

        var playerAWin = winningPlayer == 1;
        var playerBWin = winningPlayer == 2;

        foreach (var o in playerAGraphics) {
            o.SetActive(playerAWin);
        }
        
        foreach (var o in playerBGraphics) {
            o.SetActive(playerBWin);
        }
    }
}
