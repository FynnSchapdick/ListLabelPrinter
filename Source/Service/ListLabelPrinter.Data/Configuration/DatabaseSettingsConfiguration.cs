using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace ListLabelPrinter.Data.Configuration;

public sealed class DatabaseSettingsConfiguration : IConfigureOptions<DatabaseSettings>
{
    private readonly IConfiguration _configuration;

    public DatabaseSettingsConfiguration(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public void Configure(DatabaseSettings options)
    {
        options.DatabaseFile = _configuration.GetConnectionString("LiteDbConnection") ?? throw new NotImplementedException("TODO");
    }
}