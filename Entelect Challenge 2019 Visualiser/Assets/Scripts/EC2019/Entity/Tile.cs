using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace EC2019.Entity {
    public class Tile {
        [JsonProperty("x")]
        public int X { get; set; }
        
        [JsonProperty("y")]
        public int Y { get; set; }
        
        [JsonProperty("type")]
        public string TileType { get; set; }
        
        [JsonProperty("occupier")]
        public Worm Occupier { get; set; }
        
        [JsonProperty("powerup")]
        public PowerUp PowerUp { get; set; }
    }
}