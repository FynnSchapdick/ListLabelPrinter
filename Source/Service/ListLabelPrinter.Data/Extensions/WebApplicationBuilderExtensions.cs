using ListLabelPrinter.Core.Abstractions;
using ListLabelPrinter.Data.Configuration;
using ListLabelPrinter.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ListLabelPrinter.Data.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder AddData(this WebApplicationBuilder builder)
    {
        builder.Services.ConfigureOptions<DatabaseSettingsConfiguration>();
        builder.Services.AddSingleton<IPrintJobRepository>(x => new PrintJobRepository(x.GetRequiredService<IOptions<DatabaseSettings>>()));
        builder.Services.AddSingleton<ITemplateRepository>(x => new TemplateRepository(x.GetRequiredService<IOptions<DatabaseSettings>>()));
        return builder;
    }
}