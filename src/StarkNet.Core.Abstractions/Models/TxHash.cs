using System.Text.Json.Serialization;

namespace StarkNet.Core.Abstractions
{
    public class TxHash
    {
        [JsonPropertyName("tx_hash_prefix")]
        public int tx_hash_prefix { get; set; }
        [JsonPropertyName("version")]
        public string version { get; set; }
        [JsonPropertyName("contract_address")]
        public string contract_address { get; set; }
        [JsonPropertyName("error_message")]
        public string error_message { get; set; }
        [JsonPropertyName("entry_point_selector")]
        public string entry_point_selector { get; set; }
        [JsonPropertyName("calldata")]
        public string calldata { get; set; }
        [JsonPropertyName("max_fee")]
        public string max_fee { get; set; }
        [JsonPropertyName("chain_id")]
        public string chain_id { get; set; }
    }
}