using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace WpfAppBase.Services;

public sealed class BackgroundTicker : BackgroundService
{
    readonly ILogger<BackgroundTicker> _logger;
    public BackgroundTicker(ILogger<BackgroundTicker> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var pd = new PeriodicTimer(TimeSpan.FromSeconds(1));

        while (await pd.WaitForNextTickAsync(stoppingToken))
        {
            _logger.LogInformation("Tick at {time}", DateTimeOffset.Now);
        }
    }
}
