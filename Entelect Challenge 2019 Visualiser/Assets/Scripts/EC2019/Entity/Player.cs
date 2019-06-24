using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace EC2019.Entity
{
    public class Player
    {
        [JsonProperty("id")]
        private int Id { get; set; }
        [JsonProperty("score")]
        private int Score { get; set; }
        [JsonProperty("health")]
        private int Health { get; set; }
        [JsonProperty("currentWormId")]
        private int CurrentWormId { get; set; }
        [JsonProperty("remainingWormSelected")]
        private int RemainingWormSelection { get; set; }
        [JsonProperty("worms")]
        private List<Worm> Worms { get; set; }
    }
}