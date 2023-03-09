using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;


namespace ListLabelPrinter.Api.IntegrationTests;

public sealed class ListLabelPrinterApiFactory : WebApplicationFactory<AssemblyMarker>
{
    private const string ServerBaseurl = "http://localhost:80";
    
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {  
        builder.ConfigureTestServices(services =>
        {
            services.AddRefitClient<IListLabelPrintClient>(_ => new RefitSettings())
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(ServerBaseurl));
        });
        base.ConfigureWebHost(builder);
    }
}