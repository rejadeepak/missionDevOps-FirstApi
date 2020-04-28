using System;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

public class EventBusBackgroundTask:BackgroundService
{
    protected async override Task ExecuteAsync(CancellationToken stoppingToken)
    {
      while(!stoppingToken.IsCancellationRequested)
      {
        Debug.Write("Background");

        await Task.Delay(5000);

      }
    }
}