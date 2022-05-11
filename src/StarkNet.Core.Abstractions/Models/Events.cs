using System.Text.Json.Serialization;

namespace StarkNet.Core.Abstractions
{
    public class Events
    {
        [JsonPropertyName("from_address")]
        public string FromAddress { get; set; }
        [JsonPropertyName("keys")]
        public List<string> Keys { get; set; }
        [JsonPropertyName("data")]
        public List<string> Data { get; set; }
    }
}