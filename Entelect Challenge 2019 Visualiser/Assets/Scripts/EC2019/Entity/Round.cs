using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace EC2019.Entity
{
    public class Round
    {
        [JsonProperty("currentRound")]
        public int CurrentRound { get; set; }
        [JsonProperty("maxRounds")] 
        public int MaxRounds { get; set; }
        [JsonProperty("pushbackDamage")] 
        public int PushbackDamage { get; set; }
        [JsonProperty("mapSize")]
        public int MapSize { get; set; }
        [JsonProperty("currentWormId")]
        public int CurrentWormId { get; set; }
        [JsonProperty("consecutiveDoNothingCount")]
        public int ConsecutiveDoNothingCount { get; set; }
        [JsonProperty("myPlayer")]
        public Player PlayerA { get; set; }
        [JsonProperty("opponents")]
        public Player[] Opponents { get; set; }
        [JsonProperty("map")]
        public List<List<Tile>> Map { get; set; }
    }
}
