using ListLabelPrinter.Api.Features.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace ListLabelPrinter.Api.Features.Services;

public abstract class PeriodicBackgroundService : IHostedService, IDisposable
{
    private readonly PeriodicBackgroundOptions _options;
    private readonly PeriodicTimer _timer;
    
    private CancellationTokenSource? _stoppingCts;
    
    public PeriodicBackgroundService(IOptions<PeriodicBackgroundOptions> options)
    {
       _options = options.Value;
       _timer = new(TimeSpan.FromMilliseconds(_options.IntervalInMilliseconds));
    }

    public virtual async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (await _timer.WaitForNextTickAsync(stoppingToken) && !stoppingToken.IsCancellationRequested)
        {
        }
    }
    
    public Task StartAsync(CancellationToken cancellationToken)
    {
        // Create linked token to allow cancelling executing task from provided token
        _stoppingCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);

        // Store the task we're executing
        _executeTask = ExecuteAsync(_stoppingCts.Token);

        // If the task is completed then return it, this will bubble cancellation and failure to the caller
        if (_executeTask.IsCompleted)
        {
            return _executeTask;
        }

        // Otherwise it's running
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}