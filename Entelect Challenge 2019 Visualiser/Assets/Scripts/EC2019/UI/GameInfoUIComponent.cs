using EC2019.Entity;
using TMPro;
using UnityEngine;

namespace EC2019.UI {
    public class GameInfoUIComponent : MonoBehaviour {

        public SimpleHealthBar player_A_Health;
        public TMP_Text player_A_Score;
        
        public SimpleHealthBar player_B_Health;
        public TMP_Text player_B_Score;

        public string roundPrependText = "Round ";
        public TMP_Text roundNumber;
        
        public void Awake() {
            ReplayManager.nextRoundUpdateUIEvent += UpdateUI;
        }

        public void UpdateUI(GlobalState round) {

            player_A_Health.UpdateBar(round.Opponents[0].Health, 350);
            player_A_Score.text = round.Opponents[0].Score.ToString();

            player_B_Health.UpdateBar(round.Opponents[1].Health, 350);
            player_B_Score.text = round.Opponents[1].Score.ToString();

            roundNumber.text = roundPrependText + round.CurrentRound;
        }
    }
}
