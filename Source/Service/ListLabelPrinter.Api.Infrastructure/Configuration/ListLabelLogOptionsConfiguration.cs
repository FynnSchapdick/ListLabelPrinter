using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace ListLabelPrinter.Api.Infrastructure.Configuration;

public sealed class ListLabelLogOptionsConfiguration : IConfigureOptions<ListLabelLogOptions>
{
    private const string EnableLicensingLogging = "ListLabelLogging:EnableLicensing";
    private const string EnableApiCallsLogging = "ListLabelLogging:EnableApiCalls";
    private const string EnableDataProviderLogging = "ListLabelLogging:EnableDataProvider";
    private const string EnablePrinterInformationLogging = "ListLabelLogging:EnablePrinterInformation";
    private const string EnableDotNetComponentLogging = "ListLabelLogging:EnableDotNetComponent";
    private const string EnableOtherLogging = "ListLabelLogging:EnableOther";
    
    private readonly IConfiguration _configuration;
    
    public ListLabelLogOptionsConfiguration(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public void Configure(ListLabelLogOptions options)
    {
        options.EnableLicensing = _configuration.GetValue<bool>(EnableLicensingLogging);
        options.EnableApiCalls = _configuration.GetValue<bool>(EnableApiCallsLogging);
        options.EnableDataProvider = _configuration.GetValue<bool>(EnableDataProviderLogging);
        options.EnablePrinterInformation = _configuration.GetValue<bool>(EnablePrinterInformationLogging);
        options.EnableDotNetComponent = _configuration.GetValue<bool>(EnableDotNetComponentLogging);
        options.EnableOther = _configuration.GetValue<bool>(EnableOtherLogging);
    }
}