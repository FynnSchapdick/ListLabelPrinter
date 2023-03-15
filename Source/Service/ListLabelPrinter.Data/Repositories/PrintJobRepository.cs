using ListLabelPrinter.Core.Abstractions;
using ListLabelPrinter.Core.Domain;
using ListLabelPrinter.Data.Configuration;
using LiteDB;
using Microsoft.Extensions.Options;

namespace ListLabelPrinter.Data.Repositories;

public sealed class PrintJobRepository : IPrintJobRepository, IDisposable
{
    private readonly LiteRepository _liteRepository;
    public PrintJobRepository(IOptions<DatabaseSettings> options)
    {
        _liteRepository = new LiteRepository(options.Value.DatabaseFile);
    }

    public void Dispose()
    {
        _liteRepository.Dispose();
    }

    public Task<Guid> AddJob(PrintJob job, CancellationToken ct = default)
    {
        _liteRepository.Insert(job);
        return Task.FromResult(job.JobId);
    }

    public Task<IEnumerable<PrintJob>> GetPendingJobs(CancellationToken ct = default) =>
        Task.FromResult<IEnumerable<PrintJob>>(
            _liteRepository.Fetch<PrintJob>(x => x.Status == JobStatus.Pending));

    public async Task SetJobCompleted(Guid jobId, CancellationToken ct = default)
    {
        if (await GetJobById(jobId, ct) is not { } job) return;
        _liteRepository.Update(job with {Status = JobStatus.Completed});
    }

    public async Task SetJobFailed(Guid jobId, CancellationToken ct = default)
    {
        if (await GetJobById(jobId, ct) is not { } job) return;
        _liteRepository.Update(job with {Status = JobStatus.Failed});
    }

    public async Task<PrintJob?> GetJobById(Guid jobId, CancellationToken ct = default)
        => _liteRepository.SingleOrDefault<PrintJob>(x => x.JobId == jobId);
}