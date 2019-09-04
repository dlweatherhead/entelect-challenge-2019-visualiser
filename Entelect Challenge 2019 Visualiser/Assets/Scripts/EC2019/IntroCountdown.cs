using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IntroCountdown : MonoBehaviour {

    public TMP_Text countdown;
    
    void Start() {
        StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown() {
        countdown.text = "5";
        yield return new WaitForSeconds(1f);
        countdown.fontSize += 15;
        countdown.text = "4";
        yield return new WaitForSeconds(1f);
        countdown.fontSize += 15;
        countdown.text = "3";
        yield return new WaitForSeconds(1f);
        countdown.fontSize += 15;
        countdown.text = "2";
        yield return new WaitForSeconds(1f);
        countdown.fontSize += 15;
        countdown.text = "1";
        yield return new WaitForSeconds(1f);
        countdown.fontSize += 15;
        countdown.text = "!!!";
    }
}
