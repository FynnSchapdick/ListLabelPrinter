namespace ListLabelPrinter.Core.Domain;

public sealed record PrintJob(Template Template)
{
    public Guid JobId { get; init; } = Guid.NewGuid();
    public JobStatus Status { get; init; } = JobStatus.Pending;
    public Template Template { get; init; } = Template;
}