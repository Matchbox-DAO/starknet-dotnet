using Microsoft.Toolkit.Diagnostics;
using StarkNet.Core.Abstractions;

namespace StarkNet.Core;

public class Provider : IProvider
{
    public readonly HttpClient httpClient;
    public string baseUrl { get; set; } = "http://alpha4.starknet.io/";
    public string feederGatewayUrl { get; set; } = "feeder_gateway/";
    public string gatewayUrl { get; set; } = "gateway/";

    public Provider()
    {
        Guard.IsNotNull(httpClient,nameof(httpClient));
    }

    public Provider(HttpClient _httpClient)
    {
        Guard.IsNotNull(_httpClient,nameof(_httpClient));

        httpClient = _httpClient;
    }

    public Provider(HttpClient _httpClient, string _baseUrl, string _feederGatewayUrl, string _gatewayUrl)
    {
        Guard.IsNotNull(_httpClient,nameof(_httpClient));
        Guard.IsNotNull(baseUrl,nameof(baseUrl));
        Guard.IsNotNull(feederGatewayUrl,nameof(feederGatewayUrl));
        Guard.IsNotNull(gatewayUrl,nameof(gatewayUrl));

        baseUrl = _baseUrl;
        feederGatewayUrl = _feederGatewayUrl;
        gatewayUrl = _gatewayUrl;
        httpClient = _httpClient;
    }

    public async Task<bool> GetStatus()
    {
        const string path = "is_alive";
        Uri requestUri;

        HttpResponseMessage response = await httpClient.GetAsync("http://alpha4.starknet.io/feeder_gateway/is_alive");

        return response.IsSuccessStatusCode;
    }

    public async Task<ContractAddresses> GetContractAddresses()
    {
        const string path = "get_contract_addresses";
        Uri requestUri;

        HttpResponseMessage response = await httpClient.GetAsync("http://alpha4.starknet.io/feeder_gateway/get_contract_addresses");

        var contractAddresses = await response.Content.ReadAsAsync(typeof(ContractAddresses));
        
        return (ContractAddresses)contractAddresses;
    }
    
    // Getting 502 in the response from time to time, not really sure why, wonder if I should
    // have some work arround to handle this
    public async Task<Block> GetBlock(string? identifier = null)
    {
        const string path = "get_block?";
        Uri requestUri;


        //Need private method for this, it is already used in GetBlock, GetCode and GetStorageAt
        if (identifier != null)
        {
            if (identifier.StartsWith("0x"))
            {
                requestUri = new Uri(baseUrl + feederGatewayUrl + path + $"blockHash={identifier}");
            }
            else
            {
                requestUri = new Uri(baseUrl + feederGatewayUrl + path + $"blockNumber={identifier}");
            }
        }
        else
        {
            requestUri = new Uri(baseUrl + feederGatewayUrl + path);
        }

        HttpResponseMessage response = await httpClient.GetAsync(requestUri);

        var block = await response.Content.ReadAsAsync(typeof(Block));

        return (Block)block;
    }

    // Here when I specifiy some blockNumber low enough the result of the GET is empty,
    // it feels like it is looking at data until that block and not after,
    // so if contract has been deployed in later blocks, it will be null
    // even if contractAddress is correct 
    public async Task<Code> GetCode(string contractAddress, string blockIdentifier)
    {
        const string path = "contractAddress?";
        Uri requestUri;

        HttpResponseMessage response = await httpClient.GetAsync("http://alpha4.starknet.io/feeder_gateway/get_code?contractAddress=0x01d1f307c073bb786a66e6e042ec2a9bdc385a3373bb3738d95b966d5ce56166");

        var code = await response.Content.ReadAsAsync(typeof(Code));

        return (Code)code;
    }

    public async Task<string> GetStorageAt(string contractAddress, string key, string blockIdentifier)
    {
        const string path = "get_storage_at?";
        Uri requestUri;

        requestUri = new Uri(baseUrl + feederGatewayUrl + path + "contractAddress=" + contractAddress + "&key=" + key + "&blockNumber=" + blockIdentifier);

        HttpResponseMessage response = await httpClient.GetAsync(requestUri);

        var code = await response.Content.ReadAsAsync(typeof(string));

        return (string)code;
    }

    public async Task<TransactionStatus> GetTransactionStatus(string txHash)
    {
        const string path = "get_transaction_status?";
        Uri requestUri;

        requestUri = new Uri(baseUrl + feederGatewayUrl + path + "transactionHash=" + txHash);

        HttpResponseMessage response = await httpClient.GetAsync(requestUri);

        var code = await response.Content.ReadAsAsync(typeof(TransactionStatus));

        return (TransactionStatus)code;
    }

    public async Task<TransactionReceipt> GetTransactionReceipt(string txHash, string txId)
    {
        const string path = "get_transaction_receipt?";
        Uri requestUri;

        requestUri = new Uri("http://alpha4.starknet.io/feeder_gateway/get_transaction_receipt?transactionHash=0x37013e1cb9c133e6fe51b4b371b76b317a480f56d80576730754c1662582348");

        HttpResponseMessage response = await httpClient.GetAsync(requestUri);

        var code = await response.Content.ReadAsAsync(typeof(TransactionReceipt));

        return (TransactionReceipt)code;
    }

    public async Task<Transaction> GetTransaction(string txHash)
    {
        const string path = "get_transaction?";
        Uri requestUri;

        requestUri = new Uri("http://alpha4.starknet.io/feeder_gateway/get_transaction?transactionHash=0x37013e1cb9c133e6fe51b4b371b76b317a480f56d80576730754c1662582348");

        HttpResponseMessage response = await httpClient.GetAsync(requestUri);

        var code = await response.Content.ReadAsAsync(typeof(Transaction));

        return (Transaction)code;
    }

    public async Task<TransactionTrace> GetTransactionTrace(string txHash)
    {
        const string path = "get_transaction_trace?";
        Uri requestUri;

        requestUri = new Uri("http://alpha4.starknet.io/feeder_gateway/get_transaction_trace?transactionHash=0x37013e1cb9c133e6fe51b4b371b76b317a480f56d80576730754c1662582348");

        HttpResponseMessage response = await httpClient.GetAsync(requestUri);

        var code = await response.Content.ReadAsAsync(typeof(TransactionTrace));

        return (TransactionTrace)code;
    }

    public async Task<TransactionStatus> DeployContract(string txHash)
    {
        throw new NotImplementedException();
    }
}



