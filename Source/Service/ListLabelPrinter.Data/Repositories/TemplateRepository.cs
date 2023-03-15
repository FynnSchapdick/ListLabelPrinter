using ListLabelPrinter.Core.Abstractions;
using ListLabelPrinter.Core.Domain;
using ListLabelPrinter.Data.Configuration;
using LiteDB;
using Microsoft.Extensions.Options;

namespace ListLabelPrinter.Data.Repositories;

public sealed class TemplateRepository : ITemplateRepository, IDisposable
{
    private readonly LiteRepository _liteRepository;
    
    public TemplateRepository(IOptions<DatabaseSettings> options)
    {
        _liteRepository = new LiteRepository(options.Value.DatabaseFile);
    }

    public Task<Guid> AddTemplate(Template template, CancellationToken ct = default)
    {
        _liteRepository.Insert(template);
        return Task.FromResult(template.TemplateId);
    }

    public Task<IEnumerable<Template>> GetTemplates(CancellationToken ct = default) =>
        Task.FromResult<IEnumerable<Template>>(
            _liteRepository.Query<Template>().ToList());

    public async Task<Template> GetTemplateById(Guid templateId, CancellationToken ct = default)
        => _liteRepository.SingleOrDefault<Template>(x => x.TemplateId == templateId);

    public void Dispose()
    {
        _liteRepository.Dispose();
    }
}