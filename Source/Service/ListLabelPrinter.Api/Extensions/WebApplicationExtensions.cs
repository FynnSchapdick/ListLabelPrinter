using ListLabelPrinter.Api.Endpoints;
using ListLabelPrinter.Api.Middleware;
using Serilog;

namespace ListLabelPrinter.Api.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication UseApi(this WebApplication app)
    {
        app.UseSerilogRequestLogging();
        app.UseMiddleware<ExceptionMiddleware>();
        app.MapCreatePrintJobEndpoints();
        app.MapUploadTemplateEndpoints();
        return app;
    }
}