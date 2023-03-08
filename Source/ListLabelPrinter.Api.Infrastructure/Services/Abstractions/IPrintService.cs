namespace ListLabelPrinter.Api.Infrastructure.Services.Abstractions;

public interface IPrintService
{
    Task Print(PrintParameters parameters);
}