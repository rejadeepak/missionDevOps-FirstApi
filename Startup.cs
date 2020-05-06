using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using VSCodeEventBus.Manager;
using VSCodeEventBus.Mapper;
using VSCodeEventBus.Infrastructure;
using VSCodeEventBus.Domain;
using VSCodeEventBus.CQRS;
using Microsoft.OpenApi.Models;
using VSCodeEventBus.VSCodeEventBus;
using VSCodeEventBus.Handlers;
using IdentityServer4;
using IdentityModel;


namespace VSCodeEventBus
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHostedService<EventBusBackgroundTask>();

            services.AddScoped<IDataStore, DataStore>();
            services.AddScoped<IOrderMapper, OrderMapper>();
            services.AddDbContext<OrderContext>();

            services.AddScoped<IQueryHandler<OrderQuery, Order>, OrderQueryHandler>();
            services.AddScoped<ICommandHandler<OrderCommand>, OrderCommandHandler>();

            services.AddScoped<Dispatcher>();

            services.AddSingleton<IPublishManager, PublishManager>();
            services.AddSingleton<ISubscriptionManager, SubscriptionManager>();
            services.AddSingleton<IPubSubEventBus, PubSubEventBus>();
            services.AddSingleton<IProcessManager, ProcessManager>();
            services.AddSingleton<OrderRetrieveEventHandler>();
         
            services.AddHttpClient();

            // services.AddAuthentication("Bearer")
            // .AddJwtBearer("Bearer",(options)=>
            //                 {
            //                     options.Audience="EventBus";
            //                     options.RequireHttpsMetadata = false;
            //                     options.Authority="https://localhost:8000";
            //                 });
           
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EventBus API", Version = "v1" });
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();
            app.UseMiddleware<ExceptionHandlerMiddleware>();

            //app.UseMiddleware<EventBusSunscriptionMiddleware>();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "EventBus API ");
                c.RoutePrefix = string.Empty;
            });


            if (!env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseHsts();
            }

            app.UseHttpsRedirection();
           // app.UseAuthentication();
            app.UseMvc();
        }
    }
}



           