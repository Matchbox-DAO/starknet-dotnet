using System.Text.Json.Serialization;

namespace StarkNet.Core.Abstractions
{
    public class TransactionTrace
    {
        [JsonPropertyName("function_invocation")]
        public FunctionInvocation function_invocation { get; set; }
        [JsonPropertyName("signature")]
        public List<string> signature { get; set; }
    }
}