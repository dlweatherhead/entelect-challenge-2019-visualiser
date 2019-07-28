﻿using Newtonsoft.Json;
using UnityEngine;

namespace EC2019.Entity
{
    public class Worm
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("health")]
        public int Health { get; set; }
        [JsonProperty("position")]
        public Vector2 Position { get; set; }
        [JsonProperty("weapon")]
        public Weapon Weapon { get; set; }
        [JsonProperty("diggingRange")]
        public int DiggingRange { get; set; }
        [JsonProperty("movementRange")]
        public int MovementRange { get; set; }
        [JsonProperty("profession")]
        public string Profession { get; set; }
        [JsonProperty("bananaBombs")]
        public BananaBombs BananaBombs { get; set; }
    }
}
