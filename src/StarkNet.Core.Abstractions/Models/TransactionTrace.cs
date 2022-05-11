namespace StarkNet.Core.Abstractions
{
    public class TransactionTrace
    {
        public FunctionInvocation function_invocation { get; set; }
        public List<string> signature { get; set; }
    }
}