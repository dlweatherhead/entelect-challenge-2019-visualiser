using Newtonsoft.Json;

namespace EC2019.Entity {
    public class PowerUp {
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}