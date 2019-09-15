using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace EC2019.Entity {
    public class Player {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("score")]
        public int Score { get; set; }
        
        [JsonProperty("health")]
        public int Health { get; set; }
        
        [JsonProperty("currentWormId")]
        public int CurrentWormId { get; set; }
        
        [JsonProperty("remainingWormSelections")]
        public int RemainingWormSelection { get; set; }
        
        [JsonProperty("worms")]
        public List<Worm> Worms { get; set; }
    }
}