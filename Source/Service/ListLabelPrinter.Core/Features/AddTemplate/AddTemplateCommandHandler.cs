using ListLabelPrinter.Core.Abstractions;
using ListLabelPrinter.Core.Domain;
using MediatR;

namespace ListLabelPrinter.Core.Features.AddTemplate;

public sealed class AddTemplateCommandHandler : IRequestHandler<AddTemplateCommand, Guid>
{
    private readonly ITemplateRepository _templateRepository;

    public AddTemplateCommandHandler(ITemplateRepository templateRepository)
    {
        _templateRepository = templateRepository;
    }
    
    public Task<Guid> Handle(AddTemplateCommand command, CancellationToken cancellationToken)
        => _templateRepository.AddTemplate(new Template(command.FileName, command.Data), cancellationToken);
}