namespace StarkNet.Core.Abstractions
{
    public class Events
    {
        public string from_address { get; set; }
        public List<string> keys { get; set; }
        public List<string> data { get; set; }
    }
}