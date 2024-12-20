namespace IpApi.Net.Sample.Console;

public interface IIpService
{
    Task<string> GetMyIp(CancellationToken cancellationToken);
}

public class IpService : IIpService
{
    private readonly IIApiClient _apiClient;

    public IpService(IIApiClient apiClient)
    {
        _apiClient = apiClient;
    }
    public async Task<string> GetMyIp(CancellationToken cancellationToken)
    {
        var myIp = await _apiClient.QueryMyIpAsync(cancellationToken);
        var ip = await _apiClient.QueryIpAsync("1.1.1.1", cancellationToken);
        var ips = await _apiClient.QueryIpsAsync(["1.1.1.1","2.2.2.2"], cancellationToken);

        return myIp;
    }
}