using Asp.Versioning;
using Asp.Versioning.Builder;
using combit.Reporting;
using ListLabelPrinter.Api.Features.Filters;
using ListLabelPrinter.Api.Features.Models;
using ListLabelPrinter.Api.Infrastructure.Services;
using ListLabelPrinter.Api.Infrastructure.Services.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace ListLabelPrinter.Api.Features.Endpoints;

public static class PrintEndpoints
{
    private const string PrintRoute = "print";
    public static void MapPrintEndpoints(this WebApplication app)
    {
        ApiVersion printV1 = new ApiVersion(1, 0);
        ApiVersionSet versionSet = app.NewApiVersionSet()
            .HasApiVersion(printV1)
            .ReportApiVersions()
            .Build();
        
        app.MapPost(PrintRoute, PrintV1)
            .AddEndpointFilter<ValidatorFilter<PrintRequest>>()
            .WithApiVersionSet(versionSet)
            .HasApiVersion(printV1);
    }

    private static async Task<IResult> PrintV1(PrintRequest request, IPrintService printService)
    {
        await printService.Print(new PrintParameters(request.ReportFile, request.DataSource, LlLanguage.Default));
        return Results.Ok();
    }
}