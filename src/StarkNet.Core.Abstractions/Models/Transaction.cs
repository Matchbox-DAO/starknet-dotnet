using System.Text.Json.Serialization;

namespace StarkNet.Core.Abstractions
{
    public class Transaction
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }
        [JsonPropertyName("block_hash")]
        public string BlockHash { get; set; }
        [JsonPropertyName("block_number")]
        public int? BlockNumber { get; set; }
        [JsonPropertyName("transaction_index")]
        public int TransactionIndex { get; set; }
        [JsonPropertyName("transaction")]
        public TransactionChild TransactionChild { get; set; }
    }
}