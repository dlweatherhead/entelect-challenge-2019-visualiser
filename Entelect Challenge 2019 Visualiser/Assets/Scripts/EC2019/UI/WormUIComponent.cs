using System;
using EC2019.Entity;
using UnityEngine;
using TMPro;

public class WormUIComponent : MonoBehaviour {
    public TMP_Text profession;
    public TMP_Text attack;
    public TMP_Text range;
    public TMP_Text bananaCount;

    public void Start() {
        profession.text = "";
        attack.text = "";
        range.text = "";
        bananaCount.text = "";
    }

    public void UpdateUI(Worm worm) {
        profession.text = worm?.Profession;
        attack.text = worm?.Weapon?.Damage.ToString();
        range.text = worm?.Weapon?.Range.ToString();
        bananaCount.text = worm?.BananaBombs?.Count.ToString();
    }
}