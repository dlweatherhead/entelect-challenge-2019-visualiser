using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace EC2019 {
    public enum TileType {
    [JsonProperty("DEEP_SPACE")]
    [EnumMember(Value = "DEEP_SPACE")]
    DeepSpace,
    
    [JsonProperty("DIRT")]
    [EnumMember(Value = "DIRT")]
    Dirt,
    
    [JsonProperty("AIR")]
    [EnumMember(Value = "AIR")]
    Air
    }
}