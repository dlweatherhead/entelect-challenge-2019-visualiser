using System.Collections.Generic;
using Newtonsoft.Json;

namespace EC2019.Entity
{
    public class Map
    {
        [JsonProperty("tiles")]
        private List<List<Tile>> Tiles { get; set; }
    }
}