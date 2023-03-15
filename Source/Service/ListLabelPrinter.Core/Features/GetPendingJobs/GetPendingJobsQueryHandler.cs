using ListLabelPrinter.Core.Abstractions;
using ListLabelPrinter.Core.Domain;
using MediatR;
using Serilog;

namespace ListLabelPrinter.Core.Features.GetPendingJobs;

public sealed class GetPendingJobsQueryHandler : IRequestHandler<GetPendingJobsQuery, IEnumerable<PrintJob>>
{
    private readonly IPrintJobRepository _printJobRepository;

    public GetPendingJobsQueryHandler(IPrintJobRepository printJobRepository)
    {
        _printJobRepository = printJobRepository;
    }
    
    public async Task<IEnumerable<PrintJob>> Handle(GetPendingJobsQuery query, CancellationToken cancellationToken)
    {
        Log.Information(query.ToString());
        return await _printJobRepository.GetPendingJobs(cancellationToken);
    }
}