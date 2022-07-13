using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StarkNet.Core.Abstractions
{
    public class Block
    {
        [JsonPropertyName("block_hash")]
        public string BlockHash { get; set; }
        [JsonPropertyName("parent_block_hash")]
        public string ParentBlockHash { get; set; }
        [JsonPropertyName("block_number")]
        public int BlockNumber { get; set; }
        [JsonPropertyName("state_root")]
        public string StateRoot { get; set; }
        [JsonPropertyName("status")]
        public string Status { get; set; }
        [JsonPropertyName("transations")]
        public List<BlockTransaction> Transactions { get; set; }
        [JsonPropertyName("timestamp")]
        public int Timestamp { get; set; }
        [JsonPropertyName("transaction_receipts")]
        public List<TransactionReceipt> TransactionReceipt { get; set; }
        [JsonPropertyName("sequencer_address")]
        public string SequencerAddress { get; set; }
        [JsonPropertyName("gas_price")]
        public string GasPrice { get; set; }
    }
}