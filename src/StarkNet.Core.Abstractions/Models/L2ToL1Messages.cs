namespace StarkNet.Core.Abstractions
{
    public class L2ToL1Messages
    {
        public string from_address { get; set; }
        public string to_address { get; set; }
        public List<string> payload { get; set; }
    }
}