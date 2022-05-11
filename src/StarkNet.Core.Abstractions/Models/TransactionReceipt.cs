namespace StarkNet.Core.Abstractions
{
    public class TransactionReceipt
    {
        public string status { get; set; }
        public string transaction_hash { get; set; }
        public string transaction_index { get; set; }
        public string block_hash { get; set; }
        public string block_number { get; set; }
        public List<string> l2_to_l1_messages { get; set; }
        public List<string> events { get; set; }
    }
}