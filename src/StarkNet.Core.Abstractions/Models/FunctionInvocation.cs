namespace StarkNet.Core.Abstractions
{
    public class FunctionInvocation
    {
        public string caller_address { get; set; }
        public string contract_address { get; set; }
        public string code_address { get; set; }
        public string? selector { get; set; }
        public string? entry_point_type { get; set; }
        public List<string> calldata { get; set; }
        public List<string> result { get; set; }
        public ExecutionRessources execution_resources { get; set; }
        public List<string> internal_calls { get; set; }
        public List<string> events { get; set; }
        public List<string> messages { get; set; }
    }
}