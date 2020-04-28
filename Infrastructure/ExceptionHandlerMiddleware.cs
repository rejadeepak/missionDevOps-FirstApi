using System;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using VSCodeEventBus.Model;
using System.Net;
using Newtonsoft.Json;


namespace VSCodeEventBus.Infrastructure
{

    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {

            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await CreateErrorResponse(context, ex);
            }
        }

        private async Task CreateErrorResponse(HttpContext context, Exception ex)
        {
            var apiError = new ApiError()
            {
                ErrorMessage = $"Error occured during on this path {context.Request.Path}",
                Source = "EventBus",
                StatusCode = (int)HttpStatusCode.InternalServerError

            };
            
            var error = JsonConvert.SerializeObject(apiError);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;           
            await context.Response.WriteAsync(error);
        }
    }

}