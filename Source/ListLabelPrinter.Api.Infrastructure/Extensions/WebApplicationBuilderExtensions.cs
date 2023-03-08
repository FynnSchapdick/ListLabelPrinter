using combit.Reporting;
using ListLabelPrinter.Api.Infrastructure.Configuration;
using ListLabelPrinter.Api.Infrastructure.Logging;
using ListLabelPrinter.Api.Infrastructure.Services;
using ListLabelPrinter.Api.Infrastructure.Services.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ListLabelPrinter.Api.Infrastructure.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder AddPrinterInfrastructure(this WebApplicationBuilder builder)
    {
        builder.Services.ConfigureOptions<ListLabelOptionsConfiguration>();
        builder.Services.ConfigureOptions<ListLabelLogOptionsConfiguration>();
        builder.Services.AddSingleton(ListLabelFactory);
        builder.Services.AddScoped<IPrintService, PrintService>();
        return builder;
    }

    private static ListLabel ListLabelFactory(IServiceProvider provider)
    {
        var listLabelOptions = provider.GetRequiredService<IOptions<ListLabelOptions>>().Value;
        var listLabelLogOptions = provider.GetRequiredService<IOptions<ListLabelLogOptions>>();
        var ll = new ListLabel(new ListLabel2SerilogAdapter(listLabelLogOptions));
        ll.LicensingInfo = listLabelOptions.LicenseInfo;
        ll.AutoShowSelectFile = false;
        ll.AutoShowPrintOptions = false;
        return ll;
    }
}