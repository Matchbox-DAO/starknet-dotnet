namespace StarkNet.Core.Abstractions
{
    public class AbiFunctions
    {
        public List<Variables> inputs { get; set; }
        public string name { get; set; }
        public List<Variables> outputs { get; set; }
        public string type { get; set; }

        public struct Variables
        {
            string name;
            string type;
        }
    }
}