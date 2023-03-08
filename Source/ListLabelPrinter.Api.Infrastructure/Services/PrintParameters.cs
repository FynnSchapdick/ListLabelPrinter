using combit.Reporting;

namespace ListLabelPrinter.Api.Infrastructure.Services;

public sealed class PrintParameters
{
    public string ReportFile { get; }
    public object DataSource { get; }
    public LlLanguage Language { get; }

    public PrintParameters(string reportFile, object dataSource, LlLanguage language)
    {
        ReportFile = reportFile;
        DataSource = dataSource;
        Language = language;
    }
    
    public PrintParameters(string reportFile, object dataSource, string language)
    {
        ReportFile = reportFile;
        DataSource = dataSource;
        if (!Enum.TryParse(language, out LlLanguage llLanguage))
        {
            throw new NotSupportedException();
        }
        Language = llLanguage;
    }
}


