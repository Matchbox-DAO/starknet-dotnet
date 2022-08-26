using Nethereum.Signer;

using StarkNet.Core;
using StarkNet.Core.Abstractions;

public class Program
{
    static async Task Main()
    {
        var httpClient = new HttpClient();
        var provider = new HttpProvider(httpClient);

        string tx = System.IO.File.ReadAllText(@"C:\Users\tr\Documents\repos\starknet-dotnet\tests\StarkNet.Core.LocalTests\INVOKE_FUNCTION.json");
        var txResponse = await provider.AddTransaction(tx);














        //var isalive = await provider.IsAlive().ConfigureAwait(false);
        //var contractAddresses = await provider.GetContractAddresses().ConfigureAwait(false);
        //var block = await provider.GetBlock("0x2b9d0650d258656864f887eef9a28b9d318c1e5115782a2c7cc940333ee4acc").ConfigureAwait(false);
        //var code = await provider.GetCode("0x01d1f307c073bb786a66e6e042ec2a9bdc385a3373bb3738d95b966d5ce56166", "").ConfigureAwait(false);
        //var storage = await provider.GetStorageAt("0x01d1f307c073bb786a66e6e042ec2a9bdc385a3373bb3738d95b966d5ce56166", "0", "36663").ConfigureAwait(false);
        //var transactionTrace = await provider.GetTransactionTrace("0x37013e1cb9c133e6fe51b4b371b76b317a480f56d80576730754c1662582348").ConfigureAwait(false);
        //var transaction = await provider.GetTransaction("0x37013e1cb9c133e6fe51b4b371b76b317a480f56d80576730754c1662582348");
        //var transactionReceipt = await provider.GetTransactionReceipt("0x37013e1cb9c133e6fe51b4b371b76b317a480f56d80576730754c1662582348", "");
        //var transactionStatus = await provider.GetTransactionStatus("0x37013e1cb9c133e6fe51b4b371b76b317a480f56d80576730754c1662582348");

        //string text = System.IO.File.ReadAllText(@"C:\Users\tr\Documents\repos\starknet-dotnet\tests\StarkNet.Core.LocalTests\DEPLOY.json");
        //var add_transaction = await provider.AddTransaction(text);



        //var payload = new PostTransaction();
        //payload.type = "INVOKE_FUNCTION";
        //payload.max_fee = "0x5AF3107A4000";
        //payload.signature = new List<string>{"2114341841764324633924706850064818467196278761164680968341569493136426175859", "310822667156365234730222528264201870368160070372074525097690244697098161607" };
        //payload.calldata = new List<string> { "1", "2087021424722619777119509474943472645767659996348769578120564519014510906823", "232670485425082704932579856502088130646006032362877466777181098476241604910", "0", "3", "3", "170789093005611345462356874996982723414302507533280534265466014088722433815", "0", "0", "3" };
        //payload.entry_point_selector = "0x15d40a3d6ca2ac30f4031e42be28da9b056fef9bb7357ac5e85627ee876e5ad";
        //payload.contract_address = "0x0271ca0c0c9351a44d9f150bb76b3a3834fb6dea7d3302675654c489f8784554";

        //var privateKey = "0x58EA720CF457659BC13099FF91462C007105ABE2547068F814FC1367490EE3E";
        //var signer1 = new EthereumMessageSigner();
        //var msg1 = "[1,2087021424722619777119509474943472645767659996348769578120564519014510906823,232670485425082704932579856502088130646006032362877466777181098476241604910,0,3,3,170789093005611345462356874996982723414302507533280534265466014088722433815,0,0,3]";
        ////var msgarray = new byte[] { 1, 0x49D36570D4E46F48E99674BD3FCC84644DDD6B96F7C741B1562B82F9E004DC7, 232670485425082704932579856502088130646006032362877466777181098476241604910, 0, 3, 3, 170789093005611345462356874996982723414302507533280534265466014088722433815, 0, 0, 3 };
        //var txhash = "2981981147929418132269683913231291044338180915855874769681295228173021838841";
        //var signature1 = signer1.Sign(msg1., new EthECKey(privateKey));
    }
}