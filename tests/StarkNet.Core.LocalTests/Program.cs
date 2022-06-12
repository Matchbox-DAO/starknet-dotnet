using StarkNet.Core;

public class Program
{
    static async Task Main()
    {
        var httpClient = new HttpClient();
        var provider = new HttpProvider(httpClient);

        var isalive = await provider.IsAlive().ConfigureAwait(false);
        var contractAddresses = await provider.GetContractAddresses().ConfigureAwait(false);
        var block = await provider.GetBlock("0x2b9d0650d258656864f887eef9a28b9d318c1e5115782a2c7cc940333ee4acc").ConfigureAwait(false);
        var code = await provider.GetCode("0x01d1f307c073bb786a66e6e042ec2a9bdc385a3373bb3738d95b966d5ce56166", "").ConfigureAwait(false);
        var storage = await provider.GetStorageAt("0x01d1f307c073bb786a66e6e042ec2a9bdc385a3373bb3738d95b966d5ce56166", "0", "36663").ConfigureAwait(false);
        var transactionTrace = await provider.GetTransactionTrace("0x37013e1cb9c133e6fe51b4b371b76b317a480f56d80576730754c1662582348").ConfigureAwait(false);
        var transaction = await provider.GetTransaction("0x37013e1cb9c133e6fe51b4b371b76b317a480f56d80576730754c1662582348");
        var transactionReceipt = await provider.GetTransactionReceipt("0x37013e1cb9c133e6fe51b4b371b76b317a480f56d80576730754c1662582348", "");
        var transactionStatus = await provider.GetTransactionStatus("0x37013e1cb9c133e6fe51b4b371b76b317a480f56d80576730754c1662582348");

        string text = System.IO.File.ReadAllText(@"C:\Users\tr\Documents\repos\starknet-dotnet\tests\StarkNet.Core.LocalTests\DEPLOY.json");
        var add_transaction = await provider.AddTransaction(text);
    }
}