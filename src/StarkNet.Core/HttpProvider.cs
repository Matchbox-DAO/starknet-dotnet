using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Toolkit.Diagnostics;

using Newtonsoft.Json;

using StarkNet.Core.Abstractions;

using Nethereum.Web3;
using Nethereum.Util;
using System.Collections.Generic;
using Nethereum.Signer;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.ABI.Encoders;

namespace StarkNet.Core
{
    public class HttpProvider : IProvider
    {
        public readonly HttpClient httpClient;
        public string baseUrl { get; set; } = "http://alpha4.starknet.io";
        public string feederGatewayUrl { get; set; } = "/feeder_gateway";
        public string gatewayUrl { get; set; } = "/gateway";
        public Signer signer { get; set; }

        public HttpProvider()
        {
            Guard.IsNotNull(httpClient, nameof(httpClient));
        }

        public HttpProvider(HttpClient _httpClient)
        {
            Guard.IsNotNull(_httpClient, nameof(_httpClient));

            httpClient = _httpClient;
        }

        public HttpProvider(HttpClient _httpClient, string _baseUrl, string _feederGatewayUrl, string _gatewayUrl, string _account)
        {
            Guard.IsNotNull(_httpClient, nameof(_httpClient));
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

            Uri requestUri = new Uri(baseUrl + feederGatewayUrl + path);

            HttpResponseMessage response = await httpClient.GetAsync(requestUri);

            return response.IsSuccessStatusCode;
        }

        public async Task<ContractAddresses> GetContractAddresses()
        {
            const string path = "/get_contract_addresses";

            Uri requestUri = new Uri(baseUrl + feederGatewayUrl + path);

            HttpResponseMessage response = await httpClient.GetAsync(requestUri);

            var contractAddresses = await response.Content.ReadAsAsync(typeof(ContractAddresses));

            return (ContractAddresses)contractAddresses;
        }

        public async Task<Block> GetBlock(string? blockIdentifier = null)
        {
            const string path = "/get_block?";
            Uri requestUri;

            if (!String.IsNullOrWhiteSpace(blockIdentifier))
            {
                var identifier = BlockIdentifierFactory.Create(blockIdentifier);
                requestUri = new Uri(baseUrl + feederGatewayUrl + path + identifier);
            }
            else
            {
                requestUri = new Uri(baseUrl + feederGatewayUrl + path);
            }

            HttpResponseMessage response = await httpClient.GetAsync(requestUri);

            return await response.Content.ReadFromJsonAsync<Block>();
        }

        //Check behavior with blockNumber
        //make compatible with blockIdentifierFactory
        public async Task<Code> GetCode(string contractAddress, string? blockNumber = null)
        {
            const string path = "/get_code?";
            Uri requestUri;

            if (!String.IsNullOrWhiteSpace(blockNumber))
            {
                var identifier = BlockIdentifierFactory.Create(blockNumber);
                requestUri = new Uri(baseUrl + feederGatewayUrl + path + "contractAddress=" + contractAddress + "&blockNumber=" + blockNumber);
            }
            else
            {
                requestUri = new Uri(baseUrl + feederGatewayUrl + path + "contractAddress=" + contractAddress);
            }

            HttpResponseMessage response = await httpClient.GetAsync(requestUri);

            return await response.Content.ReadFromJsonAsync<Code>();
        }

        public async Task<string> GetStorageAt(string contractAddress, string key, string blockIdentifier)
        {
            const string path = "/get_storage_at?";

            var identifier = BlockIdentifierFactory.Create(blockIdentifier);
            Uri requestUri = new Uri(baseUrl + feederGatewayUrl + path + "contractAddress=" + contractAddress + "&key=" + key + identifier);

            HttpResponseMessage response = await httpClient.GetAsync(requestUri);

            var storage = await response.Content.ReadAsAsync(typeof(string));

            return (string)storage;
        }

        public async Task<TransactionStatus> GetTransactionStatus(string txHash)
        {
            const string path = "/get_transaction_status?";

            Uri requestUri = new Uri(baseUrl + feederGatewayUrl + path + "transactionHash=" + txHash);

            HttpResponseMessage response = await httpClient.GetAsync(requestUri);

            return await response.Content.ReadFromJsonAsync<TransactionStatus>();
        }

        //txId compatibility
        public async Task<TransactionReceipt> GetTransactionReceipt(string txHash, string txId)
        {
            const string path = "/get_transaction_receipt?";

            Uri requestUri = new Uri(baseUrl + feederGatewayUrl + path + "transactionHash=" + txHash);

            HttpResponseMessage response = await httpClient.GetAsync(requestUri);

            return await response.Content.ReadFromJsonAsync<TransactionReceipt>();
        }

        //txid ?
        public async Task<Transaction> GetTransaction(string txHash)
        {
            const string path = "/get_transaction?";

            Uri requestUri = new Uri(baseUrl + feederGatewayUrl + path + "transactionHash=" + txHash);

            HttpResponseMessage response = await httpClient.GetAsync(requestUri);

            return await response.Content.ReadFromJsonAsync<Transaction>();
        }

        //txid ?
        public async Task<TransactionTrace> GetTransactionTrace(string txHash)
        {
            const string path = "/get_transaction_trace?";

            Uri requestUri = new Uri(baseUrl + feederGatewayUrl + path + "transactionHash=" + txHash);

            HttpResponseMessage response = await httpClient.GetAsync(requestUri);

            return await response.Content.ReadFromJsonAsync<TransactionTrace>();
        }

        public async Task<string> AddTransaction(string payload)
        {
            const string path = "/add_transaction";

            Uri requestUri = new Uri(baseUrl + gatewayUrl + path);

            //PostTransaction payload = new PostTransaction();
            
            //var stringPayload = JsonConvert.SerializeObject(payload);

            var httpContent = new StringContent(payload, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpClient.PostAsync(requestUri, httpContent);

            var code = await response.Content.ReadAsStringAsync();

            return code;
        }

        #endregion

        #region PRIVATE
        private string formatBlockIdentifier(string blockIdentifier)
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
        #endregion
    }
}