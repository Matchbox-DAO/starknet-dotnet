namespace StarkNet.Core.Abstractions;

public class BlockTransaction
{
    public string contract_address { get; set; }
    public string entry_point_selector { get; set; }
    public string entry_point_type { get; set; }
    public List<string> calldata { get; set; }
}