using System.Text.Json.Serialization;

namespace StarkNet.Core.Abstractions
{
    public class TransactionChild
    {
        [JsonPropertyName("contract_address")]
        public string ContractAddress { get; set; }
        [JsonPropertyName("contract_address_salt")]
        public string ContractAddressSalt { get; set; }
        [JsonPropertyName("ClassHash")]
        public string class_hash { get; set; }
        [JsonPropertyName("constructor_calldata")]
        public List<string> ConstructorCalldata { get; set; }
        [JsonPropertyName("transaction_hash")]
        public string TransactionHash { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}