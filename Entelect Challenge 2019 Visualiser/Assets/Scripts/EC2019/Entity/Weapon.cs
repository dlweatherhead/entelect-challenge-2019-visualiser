using Newtonsoft.Json;

namespace EC2019.Entity
{
    public class Weapon
    {
        [JsonProperty("damage")]
        private int Damage { get; set; }
        [JsonProperty("range")]
        private int Range { get; set; }
    }
}