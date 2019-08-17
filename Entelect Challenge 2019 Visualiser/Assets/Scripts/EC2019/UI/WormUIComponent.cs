using EC2019.Entity;
using EC2019.Utility;
using TMPro;
using UnityEngine;

public class WormUIComponent : MonoBehaviour {
    public TMP_Text attackText;

    public UIItemCount bananaBombCount;

    public GameObject frozenIcon;
    public TMP_Text frozenText;

    public SimpleHealthBar healthBar;

    public TMP_Text professionText;
    public TMP_Text rangeText;
    public UIItemCount snowballCount;

    public void Start() {
        healthBar.UpdateColor(ColorPalette.LightGrey);
        
        professionText.text = "";
        attackText.text = "";
        rangeText.text = "";

        bananaBombCount.UpdateIconCount(0);
        snowballCount.UpdateIconCount(0);

        healthBar.UpdateBar(100, 100);

        frozenIcon.SetActive(false);
        frozenText.text = "";
    }

    public void UpdateUI(Worm worm, int playerId) {

        Debug.Log(worm.PlayerId);
        
        if (playerId == Constants.PlayerA.Number) {
            healthBar.UpdateColor(ColorPalette.PlayerA);
        } else if (playerId == Constants.PlayerB.Number) {
            healthBar.UpdateColor(ColorPalette.PlayerB);
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

        if (worm.RoundsUntilUnfrozen > 0) {
            frozenIcon.SetActive(true);
            frozenText.text = worm.RoundsUntilUnfrozen.ToString();
        }
        else {
            frozenIcon.SetActive(false);
            frozenText.text = "";
        }
    }
}