using EC2019.Entity;
using EC2019.Utility;
using TMPro;
using UnityEngine;

public class WormUIComponent : MonoBehaviour {
    public TMP_Text attackText;

    public UIItemCount bananaBombCount;

    public GameObject frozenIcon;

    public SimpleHealthBar healthBar;

    public TMP_Text professionText;
    public TMP_Text rangeText;
    public UIItemCount snowballCount;

    public GameObject iconAgent;
    public GameObject iconCommando;
    public GameObject iconTechnologist;
    public GameObject iconAgentDead;
    public GameObject iconCommandoDead;
    public GameObject iconTechnologistDead;

    public void Start() {
        healthBar.UpdateColor(ColorPalette.LightGrey);
        
        professionText.text = "";
        attackText.text = "";
        rangeText.text = "";
        
        iconAgent.SetActive(false);
        iconCommando.SetActive(false);
        iconTechnologist.SetActive(false);
        iconAgentDead.SetActive(false);
        iconCommandoDead.SetActive(false);
        iconTechnologistDead.SetActive(false);

        bananaBombCount.UpdateIconCount(0);
        snowballCount.UpdateIconCount(0);

        healthBar.UpdateBar(100, 100);

        frozenIcon.SetActive(false);
    }

    public void UpdateUI(Worm worm, int playerId) {
        if (playerId == Constants.PlayerA.Number) {
            healthBar.UpdateColor(ColorPalette.PlayerA);
        } else if (playerId == Constants.PlayerB.Number) {
            healthBar.UpdateColor(ColorPalette.PlayerB);
        }

        frozenIcon.SetActive(worm.RoundsUntilUnfrozen > 0);
        
        var profession = worm.Profession;
        
        if (profession.Equals(Constants.Worm.Profession.Agent)) {
            if (worm.Health <= 0) {
                iconAgentDead.SetActive(true);
                frozenIcon.SetActive(false);
            }
            else {
                iconAgent.SetActive(true);
            }
        } else if (profession.Equals(Constants.Worm.Profession.Commando)) {
            if (worm.Health <= 0) {
                iconCommandoDead.SetActive(true);
                frozenIcon.SetActive(false);
            }
            else {
                iconCommando.SetActive(true);
            }
        } else if (profession.Equals(Constants.Worm.Profession.Technologist)) {
            if (worm.Health <= 0) {
                iconTechnologistDead.SetActive(true);
                frozenIcon.SetActive(false);
            }
            else {
                iconTechnologist.SetActive(true);
            }
        }

        professionText.text = worm.Profession;
        attackText.text = worm.Weapon.Damage.ToString();
        rangeText.text = worm.Weapon.Range.ToString();

        if (worm.BananaBombs != null) {
            bananaBombCount.UpdateIconCount(worm.BananaBombs.Count);    
        }

        if (worm.SnowBalls != null) {
            snowballCount.UpdateIconCount(worm.SnowBalls.Count);    
        }

        var maxHealth = 100;
        if (worm.Profession == Constants.Worm.Profession.Commando) maxHealth = 150;

        healthBar.UpdateBar(worm.Health, maxHealth);
    }
}