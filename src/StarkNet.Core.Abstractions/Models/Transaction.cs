namespace StarkNet.Core.Abstractions
{
    public class Transaction
    {
        public string status { get; set; }
        public string block_hash { get; set; }
        public int? block_number { get; set; }
        public string transaction_index { get; set; }
        public TransactionChild transaction { get; set; }
    }
}