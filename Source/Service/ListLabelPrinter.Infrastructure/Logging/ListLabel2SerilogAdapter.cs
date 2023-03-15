using combit.Reporting;
using ListLabelPrinter.Infrastructure.Configuration;
using Microsoft.Extensions.Options;
using Serilog;
using Serilog.Events;

namespace ListLabelPrinter.Infrastructure.Logging;

public sealed class ListLabel2SerilogAdapter : LoggerBase
{
    private readonly ListLabelLogOptions _logOptions;

    public ListLabel2SerilogAdapter(IOptions<ListLabelLogOptions> logOptions)
    {
        _logOptions = logOptions.Value;
    }
    public override bool WantOutput(LogLevels level, LogCategory category)
    {
        bool isEnabled = level switch
        {
            LogLevels.Debug => Log.IsEnabled(LogEventLevel.Debug),
            LogLevels.Info => Log.IsEnabled(LogEventLevel.Information),
            LogLevels.Warning => Log.IsEnabled(LogEventLevel.Warning),
            LogLevels.Error => Log.IsEnabled(LogEventLevel.Error),
            _ => false
        };

        return isEnabled && category switch
        {
            LogCategory.API => _logOptions.EnableApiCalls,
            LogCategory.DataProvider => _logOptions.EnableDataProvider,
            LogCategory.Licensing => _logOptions.EnableLicensing,
            LogCategory.Net => _logOptions.EnableDotNetComponent,
            LogCategory.Printer => _logOptions.EnablePrinterInformation,
            _ => _logOptions.EnableOther,
        };
    }

    public override void Debug(LogCategory category, string message, params object[] args)
    {
        if (WantOutput(LogLevels.Debug, category))
        {
            Log.Debug(message, args);
        }
    }

    public override void Info(LogCategory category, string message, params object[] args)
    {
        if (WantOutput(LogLevels.Info, category))
        {
            Log.Debug(message, args);
        }
    }

    public override void Warn(LogCategory category, string message, params object[] args)
    {
        if (WantOutput(LogLevels.Warning, category))
        {
            Log.Debug(message, args);
        }
    }

    public override void Error(LogCategory category, string message, params object[] args)
    {
        if (WantOutput(LogLevels.Error, category))
        {
            Log.Debug(message, args);
        }
    }
}