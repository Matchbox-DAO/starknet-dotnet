using Microsoft.Toolkit.Diagnostics;
using StarkNet.Core.Abstractions;

namespace StarkNet.Core;

public class HttpProvider : IProvider
{
    public readonly HttpClient httpClient;
    public string baseUrl { get; set; } = "http://alpha4.starknet.io";
    public string feederGatewayUrl { get; set; } = "/feeder_gateway";
    public string gatewayUrl { get; set; } = "/gateway";

    public HttpProvider()
    {
        Guard.IsNotNull(httpClient,nameof(httpClient));
    }

    public HttpProvider(HttpClient _httpClient)
    {
        Guard.IsNotNull(_httpClient,nameof(_httpClient));

        httpClient = _httpClient;
    }

    public HttpProvider(HttpClient _httpClient, string _baseUrl, string _feederGatewayUrl, string _gatewayUrl, string _account)
    {
        Guard.IsNotNull(_httpClient,nameof(_httpClient));
        Guard.IsNotNull(_baseUrl, nameof(_baseUrl));
        Guard.IsNotNull(_feederGatewayUrl, nameof(_feederGatewayUrl));
        Guard.IsNotNull(_gatewayUrl, nameof(_gatewayUrl));

        baseUrl = _baseUrl;
        feederGatewayUrl = _feederGatewayUrl;
        gatewayUrl = _gatewayUrl;
        httpClient = _httpClient;
    }

    #region PUBLIC
    public async Task<bool> IsAlive()
    {
        const string path = "/is_alive";
        Uri requestUri;

        requestUri = new Uri(baseUrl + feederGatewayUrl + path);

        HttpResponseMessage response = await httpClient.GetAsync(requestUri);

        return response.IsSuccessStatusCode;
    }

    public async Task<ContractAddresses> GetContractAddresses()
    {
        const string path = "/get_contract_addresses";
        Uri requestUri;

        requestUri = new Uri(baseUrl + feederGatewayUrl + path);

        HttpResponseMessage response = await httpClient.GetAsync(requestUri);

        var contractAddresses = await response.Content.ReadAsAsync(typeof(ContractAddresses));
        
        return (ContractAddresses)contractAddresses;
    }

    public async Task<Block> GetBlock(string? blockIdentifier = null)
    {
        const string path = "/get_block?";
        Uri requestUri;

        if (blockIdentifier != null)
        {
            var identifier = formatBlockIdentifier(blockIdentifier);
            requestUri = new Uri(baseUrl + feederGatewayUrl + path + identifier);
        }
        else
        {
            requestUri = new Uri(baseUrl + feederGatewayUrl + path);
        }

        HttpResponseMessage response = await httpClient.GetAsync(requestUri);

        var block = await response.Content.ReadAsAsync(typeof(Block));

        return (Block)block;
    }

    public async Task<Code> GetCode(string contractAddress, string? blockIdentifier = null)
    {
        const string path = "/get_code?";
        Uri requestUri;

        if (!String.IsNullOrWhiteSpace(blockIdentifier))
        {
            var identifier = formatBlockIdentifier(blockIdentifier);
            requestUri = new Uri(baseUrl + feederGatewayUrl + path + "contractAddress=" + contractAddress + identifier);
        }
        else
        {
            requestUri = new Uri(baseUrl + feederGatewayUrl + path + "contractAddress=" + contractAddress);
        }

        HttpResponseMessage response = await httpClient.GetAsync(requestUri);

        var code = await response.Content.ReadAsAsync(typeof(Code));

        return (Code)code;
    }

    public async Task<string> GetStorageAt(string contractAddress, string key, string blockIdentifier)
    {
        const string path = "/get_storage_at?";
        Uri requestUri;
        
        var identifier = formatBlockIdentifier(blockIdentifier);
        requestUri = new Uri(baseUrl + feederGatewayUrl + path + "contractAddress=" + contractAddress + "&key=" + key + identifier);

        HttpResponseMessage response = await httpClient.GetAsync(requestUri);

        var code = await response.Content.ReadAsAsync(typeof(string));

        return (string)code;
    }

    public async Task<TransactionStatus> GetTransactionStatus(string txHash)
    {
        const string path = "/get_transaction_status?";
        Uri requestUri;

        requestUri = new Uri(baseUrl + feederGatewayUrl + path + "transactionHash=" + txHash);

        HttpResponseMessage response = await httpClient.GetAsync(requestUri);

        var code = await response.Content.ReadAsAsync(typeof(TransactionStatus));

        return (TransactionStatus)code;
    }

    //txId compatibility
    public async Task<TransactionReceipt> GetTransactionReceipt(string txHash, string txId)
    {
        const string path = "/get_transaction_receipt?";
        Uri requestUri;

        requestUri = new Uri(baseUrl + feederGatewayUrl + path + "transactionHash=" + txHash);

        HttpResponseMessage response = await httpClient.GetAsync(requestUri);

        var code = await response.Content.ReadAsAsync(typeof(TransactionReceipt));

        return (TransactionReceipt)code;
    }

    //txid ?
    public async Task<Transaction> GetTransaction(string txHash)
    {
        const string path = "/get_transaction?";
        Uri requestUri;

        requestUri = new Uri(baseUrl + feederGatewayUrl + path + "transactionHash=" + txHash);

        HttpResponseMessage response = await httpClient.GetAsync(requestUri);

        var code = await response.Content.ReadAsAsync(typeof(Transaction));

        return (Transaction)code;
    }

    //txid ?
    public async Task<TransactionTrace> GetTransactionTrace(string txHash)
    {
        const string path = "/get_transaction_trace?";
        Uri requestUri;

        requestUri = new Uri(baseUrl + feederGatewayUrl + path + "transactionHash=" + txHash);

        HttpResponseMessage response = await httpClient.GetAsync(requestUri);

        var code = await response.Content.ReadAsAsync(typeof(TransactionTrace));

        return (TransactionTrace)code;
    }

    public async Task<string> AddTransaction(string body)
    {
        const string path = "/add_transaction";
        Uri requestUri;

        requestUri = new Uri(baseUrl + gatewayUrl + path);

        var stringContent = new StringContent(body, System.Text.Encoding.UTF8, "application/json");

        HttpResponseMessage response = await httpClient.PostAsync(requestUri, stringContent);

        var code = await response.Content.ReadAsStringAsync();

        return (string)code;
    }

    #endregion

    #region PRIVATE
    private string formatBlockIdentifier(string blockIdentifier)
    {
        if (blockIdentifier.StartsWith("0x"))
        {
            return ($"&blockHash={blockIdentifier}");
        }
        else
        {
            return ($"&blockNumber={blockIdentifier}");
        }
    }
    #endregion
}