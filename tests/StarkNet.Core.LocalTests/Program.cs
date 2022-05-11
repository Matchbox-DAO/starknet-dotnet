using StarkNet.Core;

public class Program
{
    static async Task Main() {
        var httpClient = new HttpClient();
        var provider = new Provider(httpClient);

        var b = await provider.GetStatus().ConfigureAwait(false);
        var a = await provider.GetContractAddresses().ConfigureAwait(false);
        var c = await provider.GetBlock("0x2b9d0650d258656864f887eef9a28b9d318c1e5115782a2c7cc940333ee4acc").ConfigureAwait(false);
        var d = await provider.GetCode("a", "a").ConfigureAwait(false);
        var e = await provider.GetStorageAt("0x01d1f307c073bb786a66e6e042ec2a9bdc385a3373bb3738d95b966d5ce56166", "0", "36663").ConfigureAwait(false);
        var f = await provider.GetTransactionTrace("0x37013e1cb9c133e6fe51b4b371b76b317a480f56d80576730754c1662582348").ConfigureAwait(false);
        var g = await provider.GetTransaction("");
        var h = await provider.GetTransactionReceipt("", "");
        var i = await provider.GetTransactionStatus("0x37013e1cb9c133e6fe51b4b371b76b317a480f56d80576730754c1662582348");
    }
}