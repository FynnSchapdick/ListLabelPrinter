using Asp.Versioning;
using FluentValidation;
using ListLabelPrinter.Api.Features.Middleware;
using ListLabelPrinter.Api.Features.Validators;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ListLabelPrinter.Api.Features.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder AddPrinterApi(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<ExceptionMiddleware>();
        builder.Services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ApiVersionReader = new HeaderApiVersionReader("api-version");
        });
        builder.Services.AddValidatorsFromAssemblyContaining<PrintRequestValidator>();
        return builder;
    }
}