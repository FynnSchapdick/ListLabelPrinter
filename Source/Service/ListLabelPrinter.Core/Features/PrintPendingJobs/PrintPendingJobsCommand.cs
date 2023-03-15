using ListLabelPrinter.Core.Domain;
using MediatR;

namespace ListLabelPrinter.Core.Features.PrintPendingJobs;

public sealed record PrintPendingJobsCommand(IEnumerable<PrintJob> PrintJobs) : IRequest;