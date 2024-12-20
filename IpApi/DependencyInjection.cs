using Microsoft.Extensions.DependencyInjection;

namespace IpApi;

public static class DependencyInjection
{
    public static IServiceCollection AddIpApiClient(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddHttpClient();
        serviceCollection.AddScoped<IIApiClient, IpApiClient>();

        return serviceCollection;
    }
}