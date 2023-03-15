using Serilog;
using Serilog.Core;
using Serilog.Exceptions;

namespace ListLabelPrinter.Api.Extensions;

public static class LoggerConfigurationExtensions
{
    public static Logger BuildLogger(this LoggerConfiguration loggerConfiguration, IConfiguration configuration) =>
        loggerConfiguration.ReadFrom.Configuration(configuration)
            .Enrich.FromLogContext()
            .Enrich.WithExceptionDetails()
            .Enrich.WithMachineName()
            .CreateLogger();
}