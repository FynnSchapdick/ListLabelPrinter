using ListLabelPrinter.Core.Domain;
using MediatR;

namespace ListLabelPrinter.Core.Features.GetPendingJobs;

public sealed record GetPendingJobsQuery() : IRequest<IEnumerable<PrintJob>>;