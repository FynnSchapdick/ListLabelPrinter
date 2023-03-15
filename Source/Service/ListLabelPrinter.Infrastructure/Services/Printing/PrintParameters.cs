using combit.Reporting;
using combit.Reporting.DataProviders;

namespace ListLabelPrinter.Infrastructure.Services.Printing;

public sealed class PrintParameters
{
    private const string ListExtension = ".lst";
    private const string CardExtension = ".crd";
    private const string LabelExtension = ".lbl";
    public string ReportFile { get; }
    public ObjectDataProvider DataSource { get; }
    public string? PrinterName { get; }
    public LlLanguage Language { get; }
    public LlProject LlProject { get; }
    public bool Printerless { get; }

    public PrintParameters(string reportFile, object dataSource, LlLanguage? language = null, string? printerName = null, bool printerless = false)
    {
        ReportFile = reportFile;
        DataSource = new ObjectDataProvider(dataSource);
        Language = language ?? LlLanguage.Default;
        LlProject = Path.GetExtension(reportFile) switch
        {
            ListExtension => LlProject.List,
            LabelExtension => LlProject.Label,
            CardExtension => LlProject.Card,
            _ => throw new NotSupportedException()
        };
        
        PrinterName = printerName;
        Printerless = printerless;
    }
}


