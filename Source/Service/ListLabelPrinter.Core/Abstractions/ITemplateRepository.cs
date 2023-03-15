using ListLabelPrinter.Core.Domain;

namespace ListLabelPrinter.Core.Abstractions;

public interface ITemplateRepository
{
    Task<Guid> AddTemplate(Template template, CancellationToken ct = default);
    Task<IEnumerable<Template>> GetTemplates(CancellationToken ct = default);
    Task<Template> GetTemplateById(Guid templateId, CancellationToken ct = default);
}