namespace StarkNet.Core.Abstractions;

public interface IProvider
{
    string baseUrl {get; set;}
    string feederGatewayUrl {get; set;}
    string gatewayUrl {get; set;}

    Task<bool> IsAlive();
    Task<Block> GetBlock(string blockIdentifier);
    Task<Code> GetCode(string contractAddress, string blockIdentifier);
    Task<string> GetStorageAt(string contractAddress, string key, string blockIdentifier);
    Task<Transaction> GetTransaction(string txHash); //hash/number + index
    Task<TransactionStatus> GetTransactionStatus(string txHash);
    Task<TransactionReceipt> GetTransactionReceipt(string txHash, string txId);
    Task<TransactionTrace> GetTransactionTrace(string txHash);
    Task<ContractAddresses> GetContractAddresses();
}