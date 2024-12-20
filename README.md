# IpApi.Net

IpApi.Net is a .NET wrapper for IPApi, making it easy to query IP-related information in your .NET projects.

## Installation

To get started, install the IpApi NuGet package:

```bash
dotnet add package IpApi
```

## Usage

1. **Register the IpApiClient** in your service collection:

    ```csharp
    services.AddIpApiClient();
    ```

2. **Inject the `IIpApiClient`** interface into your constructor:

    ```csharp
    public class MyService
    {
        private readonly IIpApiClient _ipApiClient;

        public MyService(IIpApiClient ipApiClient)
        {
            _ipApiClient = ipApiClient;
        }

        public async Task DoSomethingAsync(CancellationToken cancellationToken)
        {
            var myIp = await _ipApiClient.QueryMyIpAsync(cancellationToken);
            var ipInfo = await _ipApiClient.QueryIpAsync("8.8.8.8", cancellationToken);
        }
    }
    ```

## Methods

The `IIpApiClient` interface exposes the following methods:

### `Task<string> QueryMyIpAsync(CancellationToken cancellationToken)`
Retrieves your public IP address.

### `Task<IpInfo?> QueryIpAsync(string ip, CancellationToken cancellationToken)`
Retrieves information about a specific IP address.

- **Parameters:**
  - `ip`: The IP address to query.
  - `cancellationToken`: A token to cancel the operation.

### `Task<IpInfo[]?> QueryIpsAsync(string[] ips, CancellationToken cancellationToken)`
Retrieves information about a collection of IP addresses.

- **Parameters:**
  - `ips`: An array of IP addresses to query.
  - `cancellationToken`: A token to cancel the operation.

## Example

```csharp
var myIp = await _ipApiClient.QueryMyIpAsync(cancellationToken);
Console.WriteLine($"My public IP: {myIp}");

var ipInfo = await _ipApiClient.QueryIpAsync("8.8.8.8", cancellationToken);
Console.WriteLine($"IP Info: {ipInfo?.City}, {ipInfo?.Country}");

var ipInfos = await _ipApiClient.QueryIpsAsync(new[] {"8.8.8.8", "1.1.1.1"}, cancellationToken);
foreach (var info in ipInfos ?? Array.Empty<IpInfo>())
{
    Console.WriteLine($"IP: {info.Ip}, City: {info.City}, Country: {info.Country}");
}
```

## License

This project is licensed under the [MIT License](LICENSE).
