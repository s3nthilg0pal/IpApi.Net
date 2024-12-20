using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IpApi.Net.Sample.Console
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddIpApiClient();
                    services.AddScoped<IIpService, IpService>();

                })
                .Build();

            var scope = host.Services.CreateScope();

            var bar = scope.ServiceProvider.GetService<IIpService>();
            var myIp = await bar.GetMyIp(CancellationToken.None);

            System.Console.WriteLine(myIp);
        }
    }
}
