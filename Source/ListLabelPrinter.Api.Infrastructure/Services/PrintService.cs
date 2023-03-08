using combit.Reporting;
using ListLabelPrinter.Api.Infrastructure.Services.Abstractions;

namespace ListLabelPrinter.Api.Infrastructure.Services;

public sealed class PrintService : IPrintService
{
    private readonly ListLabel _listLabel;

    public PrintService(ListLabel listLabel)
    {
        _listLabel = listLabel;
    }

    public Task Print(PrintParameters parameters)
    {
        _listLabel.Language = parameters.Language;
        _listLabel.AutoProjectFile = parameters.ReportFile;
        _listLabel.DataSource = new {};
        _listLabel.Print(LlProject.List, "Printer Name");
        return Task.CompletedTask;
    }
}