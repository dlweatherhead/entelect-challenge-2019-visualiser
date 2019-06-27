using Newtonsoft.Json;
using UnityEngine;

namespace EC2019.Entity
{
    public class Worm
    {
        [JsonProperty("id")]
        private int Id { get; set; }
        [JsonProperty("health")]
        private int Health { get; set; }
        [JsonProperty("position")]
        private Vector2 Position { get; set; }
        [JsonProperty("weapon")]
        private Weapon Weapon { get; set; }
        [JsonProperty("diggingRange")]
        private int DiggingRange { get; set; }
        [JsonProperty("movementRange")]
        private int MovementRange { get; set; }
        [JsonProperty("profession")]
        private string Profession { get; set; }
    }
}
