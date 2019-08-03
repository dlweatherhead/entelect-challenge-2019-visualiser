using System.Collections.Generic;
using Newtonsoft.Json;

namespace EC2019.Entity {
    public class Map {
        [JsonProperty("tiles")]
        public List<List<Tile>> Tiles { get; set; }
    }
}