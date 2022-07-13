﻿using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StarkNet.Core.Abstractions
{
    public class AbiFunctions
    {
        [JsonPropertyName("inputs")]
        public List<Variables> Inputs { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("outputs")]
        public List<Variables> Outputs { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }

        public struct Variables
        {
            string name;
            string type;
        }
    }
}