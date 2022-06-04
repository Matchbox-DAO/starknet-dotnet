using System.Text.Json.Serialization;

namespace StarkNet.Core.Abstractions
{
    public class TransactionStatus
    {
        [JsonPropertyName("tx_status")]
        public string TxStatus { get; set; }
        [JsonPropertyName("block_hash")]
        public string BlockHash { get; set; }
        [JsonPropertyName("tx_failure_reason")]
        public TxFailureReason TxFailureReason { get; set; }
    }
}