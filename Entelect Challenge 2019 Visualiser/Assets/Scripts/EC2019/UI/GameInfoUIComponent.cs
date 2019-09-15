using EC2019.Entity;
using EC2019.Utility;
using TMPro;
using UnityEngine;

namespace EC2019.UI {
    public class GameInfoUIComponent : MonoBehaviour {

        public TMP_Text player_A_Name;
        public TMP_Text player_B_Name;

        public SimpleHealthBar player_A_Health;
        public TMP_Text player_A_Score;
        public TMP_Text player_A_SelectsRemaining;
        
        public SimpleHealthBar player_B_Health;
        public TMP_Text player_B_Score;
        public TMP_Text player_B_SelectsRemaining;

        public string roundPrependText = "Round ";
        public TMP_Text roundNumber;
        
        public void Awake() {
            ReplayManager.nextRoundUpdateUIEvent += UpdateUI;

            player_A_Name.text = PlayerPrefs.GetString(Constants.PlayerPrefKeys.PlayerAName);
            player_B_Name.text = PlayerPrefs.GetString(Constants.PlayerPrefKeys.PlayerBName);
        }

        public void UpdateUI(GlobalState round) {

            player_A_Health.UpdateBar(round.Opponents[0].Health, 350);
            player_A_Score.text = round.Opponents[0].Score.ToString();

            player_B_Health.UpdateBar(round.Opponents[1].Health, 350);
            player_B_Score.text = round.Opponents[1].Score.ToString();

            roundNumber.text = roundPrependText + round.CurrentRound;

            player_A_SelectsRemaining.text = round.Opponents[0].RemainingWormSelection.ToString();
            player_B_SelectsRemaining.text = round.Opponents[1].RemainingWormSelection.ToString();
        }
    }
}
