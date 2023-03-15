namespace ListLabelPrinter.Api.Contracts;

public sealed record CreatePrintJobRequest(Guid TemplateId, object DataSource, string? Language);