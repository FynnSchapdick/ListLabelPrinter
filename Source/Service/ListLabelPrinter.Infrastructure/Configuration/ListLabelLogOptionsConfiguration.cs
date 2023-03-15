using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace ListLabelPrinter.Infrastructure.Configuration;

public sealed class ListLabelLogOptionsConfiguration : IConfigureOptions<ListLabelLogOptions>
{
    private const string EnableLicensingLogging = "ListLabel:Logging:EnableLicensing";
    private const string EnableApiCallsLogging = "ListLabel:Logging:EnableApiCalls";
    private const string EnableDataProviderLogging = "ListLabel:Logging:EnableDataProvider";
    private const string EnablePrinterInformationLogging = "ListLabel:Logging:EnablePrinterInformation";
    private const string EnableDotNetComponentLogging = "ListLabel:Logging:EnableDotNetComponent";
    private const string EnableOtherLogging = "ListLabel:Logging:EnableOther";
    
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