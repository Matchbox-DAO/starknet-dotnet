using System.Text.Json.Serialization;

namespace StarkNet.Core.Abstractions
{
    public class Code
    {
        [JsonPropertyName("bytecode")]
        public List<string> Bytecode { get; set; }
        [JsonPropertyName("abi")]
        public List<AbiFunctions> Abi { get; set; }
    }
}