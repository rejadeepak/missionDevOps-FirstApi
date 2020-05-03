using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using VSCodeEventBus.VSCodeEventBus;



public class EventBusBackgroundTask : BackgroundService
{
    IPublishManager _publishManager;
    ISubscriptionManager _subscriptionManager;

    IProcessManager _processManager;

    public EventBusBackgroundTask(IPublishManager publishManager, ISubscriptionManager subscriptionManager, IProcessManager processManager)
    {
        _publishManager = publishManager;
        _subscriptionManager = subscriptionManager;
        _processManager = processManager;
    }

    protected async override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            Debug.Write("Background");
            await Task.Delay(10000);
            var message = _publishManager.ReadMessage();

            if (message != null)
            {              
                _processManager.ProcessEvent(message);
            }
        }
    }

}
