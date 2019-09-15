using Newtonsoft.Json;

namespace EC2019.Entity {
    public class Weapon {
        [JsonProperty("damage")]
        public int Damage { get; set; }
        
        [JsonProperty("range")]
        public int Range { get; set; }
    }
}