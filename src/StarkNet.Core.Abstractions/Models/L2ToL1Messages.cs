using System.Text.Json.Serialization;

namespace StarkNet.Core.Abstractions
{
    public class L2ToL1Messages
    {
        [JsonPropertyName("from_address")]
        public string FromAddress { get; set; }
        [JsonPropertyName("to_address")]
        public string ToAddress { get; set; }
        [JsonPropertyName("payload")]
        public List<string> Payload { get; set; }
    }
}