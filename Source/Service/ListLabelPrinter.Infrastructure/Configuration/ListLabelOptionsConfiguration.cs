using ListLabelPrinter.Infrastructure.Exceptions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace ListLabelPrinter.Infrastructure.Configuration;

internal sealed class ListLabelOptionsConfiguration : IConfigureOptions<ListLabelOptions>
{
    private const string LicenseInfo = "ListLabel:LicenseInfo";

    private readonly IConfiguration _configuration;

    public ListLabelOptionsConfiguration(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(ListLabelOptions options)
    {
        options.LicenseInfo = _configuration.GetValue<string>(LicenseInfo) ?? throw new MissingRequiredConfigurationException(LicenseInfo);
    }
}