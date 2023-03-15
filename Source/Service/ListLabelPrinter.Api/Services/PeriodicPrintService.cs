using ListLabelPrinter.Api.Configuration;
using ListLabelPrinter.Core.Domain;
using ListLabelPrinter.Core.Features.GetPendingJobs;
using ListLabelPrinter.Core.Features.PrintPendingJobs;
using MediatR;
using Microsoft.Extensions.Options;

namespace ListLabelPrinter.Api.Services;

public sealed class PeriodicPrintService : BackgroundService
{
    private readonly ISender _sender;
    private readonly PeriodicTimer _periodicTimer;

    public PeriodicPrintService(IOptions<PeriodicPrintServiceOptions> options, ISender sender)
    {
        _sender = sender;
        _periodicTimer = new PeriodicTimer(TimeSpan.FromMilliseconds(options.Value.IntervallInMilliseconds));
    }
    
    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        while (await _periodicTimer.WaitForNextTickAsync(cancellationToken)
               && !cancellationToken.IsCancellationRequested)
        {
            IEnumerable<PrintJob> pendingJobs = (await _sender.Send(new GetPendingJobsQuery(), cancellationToken)).ToList();
            if (!pendingJobs.Any())
            {
                return;
            }
            await _sender.Send(new PrintPendingJobsCommand(pendingJobs), cancellationToken);
        }
    }
}