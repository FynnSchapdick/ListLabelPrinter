using ListLabelPrinter.Api.Features.Endpoints;
using ListLabelPrinter.Api.Features.Middleware;
using Microsoft.AspNetCore.Builder;

namespace ListLabelPrinter.Api.Features.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication UsePrinterApi(this WebApplication app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
        app.MapPrintEndpoints();
        return app;
    }
}