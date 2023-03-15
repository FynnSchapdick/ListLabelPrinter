using ListLabelPrinter.Api.Extensions;
using ListLabelPrinter.Core.Extensions;
using ListLabelPrinter.Data.Extensions;
using ListLabelPrinter.Infrastructure.Extensions;
using Serilog;

IConfiguration configuration = new ConfigurationBuilder()
    .BuildConfiguration(args);

Log.Logger = new LoggerConfiguration()
    .BuildLogger(configuration);

try
{
    Log.Information("Starting up...");
    
    WebApplication.CreateBuilder(args)
        .AddCore()
        .AddInfrastructure()
        .AddData()
        .AddApi()
        .Build()
        .UseApi()
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