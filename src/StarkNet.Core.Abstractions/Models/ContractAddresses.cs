using System.Text.Json.Serialization;

namespace StarkNet.Core.Abstractions
{
    public class ContractAddresses
    {
        [JsonPropertyName("Starknet")]
        public string Starknet { get; set; }
        [JsonPropertyName("GpsStatementVerifier")]
        public string GpsStatementVerifier { get; set; }
    }
}