using Asp.Versioning;
using Asp.Versioning.Builder;
using ListLabelPrinter.Core.Features.AddTemplate;
using MediatR;

namespace ListLabelPrinter.Api.Endpoints;

public static class UploadTemplateEndpoints
{
    private const string TemplatesRoute = "templates";
    private const string MultipartFormDataHeader = "multipart/form-data";
    
    public static void MapUploadTemplateEndpoints(this WebApplication app)
    {
        ApiVersion uploadTemplatetV1 = new ApiVersion(1, 0);
        ApiVersionSet uploadTemplateVersionSet = app.NewApiVersionSet()
            .HasApiVersion(uploadTemplatetV1)
            .ReportApiVersions()
            .Build();
        
        app.MapPost(TemplatesRoute, UploadTemplateV1)
            .Accepts<IFormFile>(MultipartFormDataHeader)
            .Produces(200)
            .WithApiVersionSet(uploadTemplateVersionSet)
            .HasApiVersion(uploadTemplatetV1);
    }
    
    private static async Task<IResult> UploadTemplateV1(IFormFile formFile, ISender sender, CancellationToken cancellationToken = default)
    {
        using MemoryStream ms = new MemoryStream();
        await formFile.CopyToAsync(ms, cancellationToken);
        Guid result = await sender.Send(new AddTemplateCommand(formFile.FileName, ms.ToArray()), cancellationToken);
        return Results.Ok(result);
    }
}