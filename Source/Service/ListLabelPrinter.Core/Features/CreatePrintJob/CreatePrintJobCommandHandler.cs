using ListLabelPrinter.Core.Abstractions;
using ListLabelPrinter.Core.Domain;
using MediatR;

namespace ListLabelPrinter.Core.Features.CreatePrintJob;

public sealed class CreatePrintJobCommandHandler : IRequestHandler<CreatePrintJobCommand, Guid>
{
    private readonly IPrintJobRepository _printJobRepository;
    private readonly ITemplateRepository _templateRepository;

    public CreatePrintJobCommandHandler(IPrintJobRepository printJobRepository, ITemplateRepository templateRepository)
    {
        _templateRepository = templateRepository;
        _printJobRepository = printJobRepository;
    }
    
    public async Task<Guid> Handle(CreatePrintJobCommand command, CancellationToken cancellationToken)
        => await _templateRepository.GetTemplateById(command.TemplateId, cancellationToken) is not { } template
            ? throw new NotImplementedException("TODO")
            : await _printJobRepository.AddJob(new PrintJob(template), cancellationToken);
}