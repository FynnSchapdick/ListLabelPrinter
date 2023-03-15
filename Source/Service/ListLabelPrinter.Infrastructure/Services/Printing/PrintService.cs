using ListLabelPrinter.Infrastructure.Services.Printing.Abstractions;

namespace ListLabelPrinter.Infrastructure.Services.Printing;

public sealed class PrintService : IPrintService
{
    private readonly IPrinter _printer;
    public PrintService(IPrinter printer)
    {
        _printer = printer;
    }

    public async Task Print(PrintParameters parameters)
    {
        _printer.DataSource = parameters.DataSource;
        _printer.Language = parameters.Language;
        _printer.Printerless = parameters.Printerless;
        if (string.IsNullOrEmpty(parameters.PrinterName))
        {
            _printer.AutoProjectFile = parameters.ReportFile;
            _printer.AutoProjectType = parameters.LlProject;
            _printer.Print();
            await Task.CompletedTask;
            return;
        }

        _printer.Print();
        await Task.CompletedTask;
    }
}