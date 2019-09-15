using System.Collections.Generic;
using Newtonsoft.Json;

namespace EC2019.Entity {
    public class GlobalState {
        [JsonProperty("currentRound")] 
        public int CurrentRound { get; set; }
        
        [JsonProperty("maxRounds")] 
        public int maxRounds { get; set; }
        
        [JsonProperty("pushbackDamage")] 
        public int PushbackDamage { get; set; }
        
        [JsonProperty("lavaDamage")] 
        public int LavaDamage{ get; set; }
        
        [JsonProperty("mapSize")] 
        public int MapSize { get; set; }
        
        [JsonProperty("opponents")] 
        public List<Player> Opponents { get; set; }
        
        [JsonProperty("map")] 
        public List<List<Tile>> Map { get; set; }
        
        [JsonProperty("visualizerEvents")] 
        public List<VisualiserEvent> VisualizerEvents { get; set; }
    }
}