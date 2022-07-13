
using Microsoft.Toolkit.Diagnostics;

namespace StarkNet.Core
{
    public static class BlockIdentifierFactory
    {
        public static string Create(string blockIdentifier)
        {
            Guard.IsNotNull(blockIdentifier, nameof(blockIdentifier));
            if (blockIdentifier.StartsWith("0x"))
            {
                return ($"&blockHash={blockIdentifier}");
            }
            else
            {
                return ($"&blockNumber={blockIdentifier}");
            }
        }
    }
}