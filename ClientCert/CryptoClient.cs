using System.Net.Security;

namespace ClientCert;

public class CryptoClient
{
    private readonly HttpClient client;

    public CryptoClient(HttpClient client)
    {
        this.client = client;
    }
    
    public async Task<string> GetAsync(string url)
    {
        var response = await client.GetAsync(url);
        return await response.Content.ReadAsStringAsync();
    }
}