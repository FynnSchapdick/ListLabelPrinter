namespace ListLabelPrinter.Api.Features.Models;

public sealed class PrintRequest
{
    public string ReportFile { get; set; }
    public object DataSource { get; set; }
}