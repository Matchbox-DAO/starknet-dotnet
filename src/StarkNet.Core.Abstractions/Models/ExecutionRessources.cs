using System.Text.Json.Serialization;

namespace StarkNet.Core.Abstractions
{
    public class ExecutionRessources
    {
        [JsonPropertyName("n_steps")]
        public int NSteps { get; set; }
        [JsonPropertyName("builtin_instance_counter")]
        public BuiltinInstanceCounter BuiltinInstanceCounter { get; set; }
        [JsonPropertyName("n_memory_holes")]
        public int NMemoryHoles { get; set; }
    }
}