namespace StarkNet.Core.Abstractions
{
    public class ExecutionRessources
    {
        public int n_steps { get; set; }
        public BuiltinInstanceCounter builtin_instance_counter { get; set; }
        public int n_memory_holes { get; set; }
    }
}