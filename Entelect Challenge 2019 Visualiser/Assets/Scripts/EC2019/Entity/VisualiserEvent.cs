using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace EC2019.Entity {
    public class VisualiserEvent {
        [JsonProperty("type")] 
        public string Type { get; set; }
        
        [JsonProperty("result")] 
        public string Result { get; set; }
        
        [JsonProperty("positionStart")] 
        public Vector2 PositionStart { get; set; }
        
        [JsonProperty("positionEnd")] 
        public Vector2 PositionEnd { get; set; }
        
        [JsonProperty("wormCommanded")] 
        public WormCommanded WormCommanded { get; set; }
        
        [JsonProperty("affectedCells")] 
        public List<Tile> AffectedCells { get; set; }
    }
}