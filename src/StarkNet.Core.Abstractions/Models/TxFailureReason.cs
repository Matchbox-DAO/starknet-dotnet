using System.Text.Json.Serialization;

namespace StarkNet.Core.Abstractions
{
    public class TxFailureReason
    {
        [JsonPropertyName("tx_id")]
        public int TxId { get; set; }
        [JsonPropertyName("code")]
        public string Code { get; set; }
        [JsonPropertyName("error_message")]
        public string? ErrorMessage { get; set; }
    }
}