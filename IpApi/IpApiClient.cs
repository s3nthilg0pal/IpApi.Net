using System.Text.Json;

namespace IpApi;

public class IpApiClient : IIApiClient
{
    private readonly IHttpClientFactory _httpClientFactory;
    private const string BaseUrl = "https://api.ipquery.io/";

    public IpApiClient(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<string> QueryMyIpAsync(CancellationToken cancellationToken)
    {
        using var httpClient = _httpClientFactory.CreateClient();

        var response = await httpClient.GetAsync(new Uri(BaseUrl), cancellationToken);

        await HandleErrorAsync(cancellationToken, response);

        var ip = await response.Content.ReadAsStringAsync(cancellationToken);

        return ip;
    }

    private static async Task HandleErrorAsync(CancellationToken cancellationToken, HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode)
        {
            var unsuccessfulResponse = await response.Content.ReadAsStringAsync(cancellationToken);

            throw new IpApiClientException(unsuccessfulResponse);
        }
    }

    public async Task<IpInfo?> QueryIpAsync(string ip, CancellationToken cancellationToken)
    {
        using var httpClient = _httpClientFactory.CreateClient();
        httpClient.BaseAddress = new Uri(BaseUrl);

        var response = await httpClient.GetAsync(ip, cancellationToken);

        await HandleErrorAsync(cancellationToken, response);

        var result = await response.Content.ReadAsStringAsync(cancellationToken);

        var ipInfo = JsonSerializer.Deserialize<IpInfo>(result);
        return ipInfo;
    }

    public async Task<IpInfo[]?> QueryIpsAsync(string[] ips, CancellationToken cancellationToken)
    {
        using var httpClient = _httpClientFactory.CreateClient();
        httpClient.BaseAddress = new Uri(BaseUrl);

        var allIps = string.Join(" ", ips);

        var response = await httpClient.GetAsync(allIps, cancellationToken);

        await HandleErrorAsync(cancellationToken, response);

        var result = await response.Content.ReadAsStringAsync(cancellationToken);

        var ipsInfo = JsonSerializer.Deserialize<IpInfo[]>(result);

        return ipsInfo;
    }
}

public interface IIApiClient
{
    Task<string> QueryMyIpAsync(CancellationToken cancellationToken);
    Task<IpInfo?> QueryIpAsync(string ip, CancellationToken cancellationToken);
    Task<IpInfo[]?> QueryIpsAsync(string[] ip, CancellationToken cancellationToken);
}