namespace ListLabelPrinter.Infrastructure.Services.Printing.Abstractions;

public interface IPrintService
{
    Task Print(PrintParameters parameters);
}