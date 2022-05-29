namespace StarkNet.Core.Abstractions
{
    public class Block
    {
        public string block_hash { get; set; }
        public string parent_block_hash { get; set; }
        public int block_number { get; set; }
        public string state_root { get; set; }
        public string status { get; set; }
        public List<BlockTransaction> transations { get; set; }
        public string timestamp { get; set; }
        public List<TransactionReceipts> transaction_receipts { get; set; }
        public string sequencer_address { get; set; }
        public string gas_price { get; set; }
    }
}