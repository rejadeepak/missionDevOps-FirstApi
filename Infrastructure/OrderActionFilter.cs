using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Controllers;
using System.ComponentModel.DataAnnotations;

namespace VSCodeEventBus.Infrastructure
{
    public class OrderConActionFilter : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
        
            await next();

        }
    }
}
