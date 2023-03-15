using Microsoft.Extensions.Options;

namespace ListLabelPrinter.Api.Configuration;

public sealed class PeriodicPrintServiceOptionsConfiguration : IConfigureOptions<PeriodicPrintServiceOptions>
{
    private const string IntervallInMilliseconds = "PrintService:IntervallInMilliseconds";
    
    private readonly IConfiguration _configuration;

    public PeriodicPrintServiceOptionsConfiguration(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public void Configure(PeriodicPrintServiceOptions options)
    {
        options.IntervallInMilliseconds = _configuration.GetValue<int>(IntervallInMilliseconds);
    }
}