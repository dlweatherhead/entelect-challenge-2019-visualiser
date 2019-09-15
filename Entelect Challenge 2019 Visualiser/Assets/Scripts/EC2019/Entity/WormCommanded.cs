using Newtonsoft.Json;

namespace EC2019.Entity {
    public class WormCommanded {
        [JsonProperty("id")] 
        public int Id { get; set; }
        
        [JsonProperty("playerId")] 
        public int PlayerId { get; set; }
        
    }
}