namespace ListLabelPrint.HttpClient.Requests;

public sealed record PrintRequest(string ReportFile, object DataSource);