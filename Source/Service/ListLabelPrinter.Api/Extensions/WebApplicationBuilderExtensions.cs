using Asp.Versioning;
using FluentValidation;
using ListLabelPrinter.Api.Configuration;
using ListLabelPrinter.Api.Middleware;
using ListLabelPrinter.Api.Services;
using ListLabelPrinter.Api.Validators;
using Serilog;

namespace ListLabelPrinter.Api.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder AddApi(this WebApplicationBuilder builder)
    {
        builder.Host.UseSerilog();
        builder.Services.AddTransient<ExceptionMiddleware>();
        builder.Services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ApiVersionReader = new HeaderApiVersionReader("api-version");
        });
        builder.Services.AddValidatorsFromAssemblyContaining<PrintRequestValidator>();
        builder.Services.ConfigureOptions<PeriodicPrintServiceOptionsConfiguration>();
        builder.Services.AddHostedService<PeriodicPrintService>();
        return builder;
    }
}