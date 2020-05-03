using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using VSCodeEventBus.VSCodeEventBus;
using VSCodeEventBus.Handlers;

namespace VSCodeEventBus.Infrastructure
{

    public class EventBusSunscriptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IPubSubEventBus _pubSubEventBus;
        public EventBusSunscriptionMiddleware(RequestDelegate next, IPubSubEventBus pubSubEventBus)
        {
            _next = next;
            _pubSubEventBus = pubSubEventBus;
        }

        public async Task Invoke(HttpContext context)
        {
            _pubSubEventBus.Subscribe<OrderRetrieveEvent,OrderRetrieveEventHandler>();
            await _next(context);
        }

    }
}