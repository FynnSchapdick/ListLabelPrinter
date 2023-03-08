using ListLabelPrinter.Api.Features.Extensions;
using ListLabelPrinter.Api.Infrastructure.Extensions;
using Serilog;

IConfiguration configuration = new ConfigurationBuilder()
    .BuildConfiguration(args);

Log.Logger = new LoggerConfiguration()
    .BuildLogger(configuration);

try
{
    Log.Information("Starting up...");
    
    WebApplication.CreateBuilder(args)
        .AddPrinterInfrastructure()
        .AddPrinterApi()
        .Build()
        .UsePrinterApi()
        .Run();
    
    Log.Information("Shutting down...");
}
catch (Exception exception)
{
    Log.Fatal(exception, "Api host terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}