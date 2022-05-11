namespace StarkNet.Core.Abstractions;

public class BuiltinInstanceCounter
{
    public int pedersen_builtin { get; set; }
    public int range_check_builtin { get; set; }
    public int ecdsa_builtin { get; set; }
    public int output_builtin { get; set; }
    public int bitwise_builtin { get; set; }
    public int ec_op_builtin { get; set; }
}
