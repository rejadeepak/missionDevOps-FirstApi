using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using VSCodeEventBus.Handlers;
using VSCodeEventBus.VSCodeEventBus;

namespace VSCodeEventBus
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var webHost = CreateWebHostBuilder(args).Build();

            var scope = webHost.Services.CreateScope();
            var provider = scope.ServiceProvider;        
            var eventBus = provider.GetRequiredService<IPubSubEventBus>();
            eventBus.Subscribe<OrderRetrieveEvent,OrderRetrieveEventHandler>();


            webHost.Run();

            //.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
