using System.Text.Json.Serialization;

namespace StarkNet.Core.Abstractions
{
    public class TransactionReceipt
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }
        [JsonPropertyName("transaction_hash")]
        public string TransactionHash { get; set; }
        [JsonPropertyName("transaction_index")]
        public int TransactionIndex { get; set; }
        [JsonPropertyName("block_hash")]
        public string BlockHash { get; set; }
        [JsonPropertyName("block_number")]
        public int BlockNumber { get; set; }
        [JsonPropertyName("l2_to_l1_messages")]
        public List<L2ToL1Messages> L2ToL1Messages { get; set; }
        [JsonPropertyName("events")]
        public List<Events> Events { get; set; }
        [JsonPropertyName("execution_resources")]
        public ExecutionRessources ExecutionRessources { get; set; }
    }
}