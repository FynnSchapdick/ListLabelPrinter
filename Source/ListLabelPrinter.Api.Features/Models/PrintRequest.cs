namespace ListLabelPrinter.Api.Features.Models;

public sealed record PrintRequest(string ReportFile, object DataSource);