namespace ListLabelPrinter.Api.Data.Entities;

public sealed class PrintJobEntity
{
    public Guid Id { get; set; }
    public string ReportFile { get; set; }
}