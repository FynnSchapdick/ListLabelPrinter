using combit.Reporting;
using ListLabelPrinter.Infrastructure.Configuration;
using ListLabelPrinter.Infrastructure.Logging;
using ListLabelPrinter.Infrastructure.Services.Printing;
using ListLabelPrinter.Infrastructure.Services.Printing.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ListLabelPrinter.Infrastructure.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder AddInfrastructure(this WebApplicationBuilder builder)
    {
        builder.Services.ConfigureOptions<ListLabelOptionsConfiguration>();
        builder.Services.ConfigureOptions<ListLabelLogOptionsConfiguration>();
        builder.Services.AddSingleton(ListLabelFactory);
        builder.Services.AddScoped<IPrinter, Services.Printing.LlPrinter>();
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