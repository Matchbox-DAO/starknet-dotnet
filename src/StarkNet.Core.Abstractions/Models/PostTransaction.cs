using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StarkNet.Core.Abstractions
{
    public class PostTransaction
    {
        [JsonPropertyName("max_fee")]
        public string max_fee { get; set; }
        [JsonPropertyName("entry_point_selector")]
        public string entry_point_selector { get; set; }
        [JsonPropertyName("signature")]
        public List<string> signature { get; set; }
        [JsonPropertyName("contract_address")]
        public string contract_address { get; set; }
        [JsonPropertyName("type")]
        public string type { get; set; } //INVOKE_FUNCTION
        [JsonPropertyName("calldata")]
        public List<string> calldata { get; set; }
        [JsonPropertyName("version")]
        public string version { get; set; }
    }
}
