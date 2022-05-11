namespace StarkNet.Core.Abstractions
{
    public class TransactionReceipts
    {
        public int transaction_index { get; set; }
        public string transaction_hash { get; set; }
        public List<L2ToL1Messages> l2_to_l1_messages { get; set; }
        public List<Events> events { get; set; }
        public ExecutionRessources execution_resources { get; set; }
        public string actual_fee { get; set; }
    }
}