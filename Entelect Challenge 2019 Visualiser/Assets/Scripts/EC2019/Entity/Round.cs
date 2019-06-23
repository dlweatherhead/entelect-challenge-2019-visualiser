using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EC2019.Entity
{
    public class Round : MonoBehaviour
    {
        private int CurrentRound { get; set; }
        private int MaxRounds { get; set; }
        private int PushbackDamage { get; set; }
        private int MapSize { get; set; }
        private int CurrentWormId { get; set; }
        private int ConsecutiveDoNothingCount { get; set; }
        private Player PlayerA { get; set; }
        private Player[] Opponents { get; set; }
        private Map Map { get; set; }
    }
}
