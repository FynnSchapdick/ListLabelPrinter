using Microsoft.Extensions.Hosting;

namespace ListLabelPrinter.Api.Features.Services;

public sealed class PeriodicBackgroundPrintService : BackgroundService
{
    private readonly PeriodicTimer _timer = new(TimeSpan.FromMilliseconds(1000));

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (await _timer.WaitForNextTickAsync(stoppingToken) && !stoppingToken.IsCancellationRequested)
        {
            // Daten holen
            
            await DoWork();
        }
    }

    private static async Task DoWork()
    {
        Console.WriteLine(DateTime.Now.ToString("O"));
        await Task.Delay(500);
    }
}