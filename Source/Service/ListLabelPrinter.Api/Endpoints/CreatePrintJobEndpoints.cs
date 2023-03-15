using Asp.Versioning;
using Asp.Versioning.Builder;
using ListLabelPrinter.Api.Contracts;
using ListLabelPrinter.Api.Filters;
using ListLabelPrinter.Core.Features.CreatePrintJob;
using MediatR;

namespace ListLabelPrinter.Api.Endpoints;

public static class CreatePrintJobEndpoints
{
    private const string PrintRoute = "printjobs";
    public static void MapCreatePrintJobEndpoints(this WebApplication app)
    {
        ApiVersion createPrintJobV1 = new ApiVersion(1, 0);
        ApiVersionSet createPrintJobVersionSet = app.NewApiVersionSet()
            .HasApiVersion(createPrintJobV1)
            .ReportApiVersions()
            .Build();
        
        app.MapPost(PrintRoute, CreatePrintJobV1)
            .AddEndpointFilter<ValidatorFilter<CreatePrintJobRequest>>()
            .WithApiVersionSet(createPrintJobVersionSet)
            .HasApiVersion(createPrintJobV1);
    }

    private static async Task<IResult> CreatePrintJobV1(CreatePrintJobRequest request, ISender sender)
    {
        Guid result = await sender.Send(new CreatePrintJobCommand(request.TemplateId, request.DataSource, request.Language));
        return Results.Ok(result);
    }
}