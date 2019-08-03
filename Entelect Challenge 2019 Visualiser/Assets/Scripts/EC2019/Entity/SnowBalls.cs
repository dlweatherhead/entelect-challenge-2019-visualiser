using Newtonsoft.Json;

namespace EC2019.Entity {
    public class SnowBalls {
        [JsonProperty("freezeDuration")]
        public int FreezeDuration { get; set; }
        
        [JsonProperty("range")]
        public int Range { get; set; }
        
        [JsonProperty("count")]
        public int Count { get; set; }
        
        [JsonProperty("freezeRadius")]
        public int FreezeRadius { get; set; }
    }
}