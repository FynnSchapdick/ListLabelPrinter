using MediatR;

namespace ListLabelPrinter.Core.Features.PrintPendingJobs;

public sealed class PrintPendingJobsCommandHandler : IRequestHandler<PrintPendingJobsCommand>
{
    public Task Handle(PrintPendingJobsCommand command, CancellationToken cancellationToken)
    {

        return Task.CompletedTask;
    }
}