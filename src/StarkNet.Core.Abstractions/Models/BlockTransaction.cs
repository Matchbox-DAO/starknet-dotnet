using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StarkNet.Core.Abstractions
{
public class BlockTransaction
{
    [JsonPropertyName("contract_address")]
    public string ContractAddress { get; set; }
    [JsonPropertyName("entry_point_selector")]
    public string EntryPointSelector { get; set; }
    [JsonPropertyName("entry_point_type")]
    public string EntryPointType { get; set; }
    [JsonPropertyName("calldata")]
    public List<string> Calldata { get; set; }
}
}