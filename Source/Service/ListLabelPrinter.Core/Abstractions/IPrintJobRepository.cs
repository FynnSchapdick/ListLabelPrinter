using ListLabelPrinter.Core.Domain;

namespace ListLabelPrinter.Core.Abstractions;

public interface IPrintJobRepository
{
    Task<Guid> AddJob(PrintJob job, CancellationToken ct = default);
    Task<IEnumerable<PrintJob>> GetPendingJobs(CancellationToken ct = default);
    Task SetJobCompleted(Guid jobId, CancellationToken ct = default);
    Task SetJobFailed(Guid jobId, CancellationToken ct = default);
    Task<PrintJob?> GetJobById(Guid jobId, CancellationToken ct = default);
}