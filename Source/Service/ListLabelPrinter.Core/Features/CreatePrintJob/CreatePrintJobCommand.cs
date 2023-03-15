using MediatR;

namespace ListLabelPrinter.Core.Features.CreatePrintJob;

public sealed record CreatePrintJobCommand(Guid TemplateId, object DataSource, string? Language) : IRequest<Guid>;