using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EC2019.Entity
{
    public class Player
    {
        private int Id { get; set; }
        private int Score { get; set; }
        private int Health { get; set; }
        private int CurrentWormId { get; set; }
        private int RemainingWormSelection { get; set; }
        private List<Worm> Worms { get; set; }
    }
}