using combit.Reporting;

namespace ListLabelPrinter.Api.Infrastructure.Services;

public sealed class PrintParameters
{
    private const string List = ".lst";
    private const string Card = ".crd";
    private const string Label = ".lbl";
    
    public string ReportFile { get; }
    public string? PrinterName { get; }
    public object DataSource { get; }
    public LlLanguage? Language { get; }
    public LlProject LlProject { get; }

    public PrintParameters(string reportFile, object dataSource, LlLanguage language, string? printerName = null)
    {
        ReportFile = reportFile;
        DataSource = dataSource;
        Language = language;
        LlProject = Path.GetExtension(reportFile) switch
        {
            List => LlProject.List,
            Label => LlProject.Label,
            Card => LlProject.Card,
            _ => throw new NotSupportedException()
        };
        
        PrinterName = printerName;
    }
    
    public PrintParameters(string reportFile, object dataSource, string language, string? printerName = null)
    {
        ReportFile = reportFile;
        DataSource = dataSource;
        if (!Enum.TryParse(language, out LlLanguage llLanguage))
        {
            throw new NotSupportedException();
        }
        Language = llLanguage;
        LlProject = Path.GetExtension(reportFile) switch
        {
            List => LlProject.List,
            Label => LlProject.Label,
            Card => LlProject.Card,
            _ => throw new NotSupportedException()
        };
        
        PrinterName = printerName;
    }
}


