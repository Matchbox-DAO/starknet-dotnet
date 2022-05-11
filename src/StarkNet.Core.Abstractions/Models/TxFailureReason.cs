namespace StarkNet.Core.Abstractions
{
    public class TxFailureReason
    {
        public int tx_id { get; set; }
        public string code { get; set; }
        public string? error_message { get; set; }
    }
}