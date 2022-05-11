namespace StarkNet.Core.Abstractions
{
    public class TransactionStatus
    {
        public string tx_status { get; set; }
        public string block_hash { get; set; }
        public TxFailureReason tx_failure_reason { get; set; }
    }
}