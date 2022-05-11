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
}