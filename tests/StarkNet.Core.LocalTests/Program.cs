using StarkNet.Core;

public class Program
{
    static async Task Main() {
        var httpClient = new HttpClient();
        var provider = new Provider(httpClient);

        var b = await provider.GetStatus().ConfigureAwait(false);
        var a = await provider.GetContractAddresses().ConfigureAwait(false);
        var c = await provider.GetBlock("0x2b9d0650d258656864f887eef9a28b9d318c1e5115782a2c7cc940333ee4acc").ConfigureAwait(false);
        var d = await provider.GetCode("a","a").ConfigureAwait(false);
    }
}