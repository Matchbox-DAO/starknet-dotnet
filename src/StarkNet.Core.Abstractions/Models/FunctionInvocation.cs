using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StarkNet.Core.Abstractions
{
    public class FunctionInvocation
    {
        [JsonPropertyName("caller_address")]
        public string CallerAddress { get; set; }
        [JsonPropertyName("contract_address")]
        public string ContractAddress { get; set; }
        [JsonPropertyName("code_address")]
        public string CodeAddress { get; set; }
        [JsonPropertyName("selector")]
        public string? Selector { get; set; }
        [JsonPropertyName("entry_point_type")]
        public string? EntryPointType { get; set; }
        [JsonPropertyName("calldata")]
        public List<string> Calldata { get; set; }
        [JsonPropertyName("result")]
        public List<string> Result { get; set; }
        [JsonPropertyName("execution_resources")]
        public ExecutionRessources ExecutionRessources { get; set; }
        [JsonPropertyName("internal_calls")]
        public List<string> InternalCalls { get; set; }
        [JsonPropertyName("events")]
        public List<string> Events { get; set; }
        [JsonPropertyName("messages")]
        public List<string> Messages { get; set; }
    }
}