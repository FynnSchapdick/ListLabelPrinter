namespace ListLabelPrinter.Api.Extensions;

public static class ConfigurationBuilderExtensions
{
    public static IConfiguration BuildConfiguration(this ConfigurationBuilder builder, string[] args) =>
        builder
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false, true)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", true,
                true)
            .AddCommandLine(args)
            .AddEnvironmentVariables()
            .Build();
}