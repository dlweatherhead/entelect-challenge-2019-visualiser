using Newtonsoft.Json;

namespace EC2019.Entity {
    public class BananaBombs {
        [JsonProperty("damage")]
        public int Damage { get; set; }
        
        [JsonProperty("range")]
        public int Range { get; set; }
        
        [JsonProperty("count")]
        public int Count { get; set; }
        
        [JsonProperty("damageRadius")]
        public int DamageRadius { get; set; }
    }
}