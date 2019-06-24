using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace EC2019.Entity
{
    public class Tile
    {
        [JsonProperty("x")]
        private int X { get; set; }
        [JsonProperty("y")]
        private int Y { get; set; }
        [JsonProperty("tileType")]
        private string TileType { get; set; }
    }
}