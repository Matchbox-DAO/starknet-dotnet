namespace StarkNet.Core.Abstractions
{
    public class TransactionChild
    {
        public string contract_address { get; set; }
        public string contract_address_salt { get; set; }
        public string class_hash { get; set; }
        public List<string> constructor_calldata { get; set; }
        public string transaction_hash { get; set; }
        public string type { get; set; }
    }
}