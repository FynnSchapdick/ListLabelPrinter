using MediatR;

namespace ListLabelPrinter.Core.Features.AddTemplate;

public sealed record AddTemplateCommand(string FileName, byte[] Data) : IRequest<Guid>;