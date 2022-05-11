namespace StarkNet.Core.Abstractions;

public interface IProvider
{    
    string baseUrl {get; set;}
    string feederGatewayUrl {get; set;}
    string gatewayUrl {get; set;}

    Task<bool> GetStatus();
    Task<ContractAddresses> GetContractAddresses();
    Task<Block> GetBlock(string identifier);
    Task<Code> GetCode(string contractAddress, string blockIdentifier);
    Task<string> GetStorageAt(string contractAddress, string key, string blockIdentifier);
    Task<TransactionStatus> GetTransactionStatus(string txHash);
    Task<TransactionReceipt> GetTransactionReceipt(string txHash, string txId);
    Task<Transaction> GetTransaction(string txHash);
    Task<TransactionTrace> GetTransactionTrace(string txHash);
    Task<TransactionStatus> DeployContract(string txHash);
}