using System.Text.Json.Serialization;

namespace StarkNet.Core.Abstractions
{
public class BuiltinInstanceCounter
{
    [JsonPropertyName("pedersen_builtin")]
    public int PedersenBuiltin { get; set; }
    [JsonPropertyName("range_check_builtin")]
    public int RangeCheckBuiltin { get; set; }
    [JsonPropertyName("ecdsa_builtin")]
    public int EcdsaBuiltin { get; set; }
    [JsonPropertyName("output_builtin")]
    public int OutputBuiltin { get; set; }
    [JsonPropertyName("bitwise_builtin")]
    public int BitwiseBuiltin { get; set; }
    [JsonPropertyName("EcOpBuiltin")]
    public int ec_op_builtin { get; set; }
}
}