using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using VSCodeEventBus.Domain;
using VSCodeEventBus.Controllers.Misc;

namespace VSCodeEventBus.CQRS
{

    public class Dispatcher
    {
        private readonly IServiceProvider _provider;
        public Dispatcher(IServiceProvider provider)
        {
            _provider = provider;

        }
        // services.AddScoped<IQueryHandler<OrderQuery, Order>, OrderQueryHandler>();
        public TResult Dispatch<TResult>(IQuery<TResult> query)
        {
            var queryHandlerType = typeof(IQueryHandler<,>);
            var queryType = query.GetType();
            var resultType = typeof(TResult);

            var types = new[] { queryType, resultType };
            queryHandlerType = queryHandlerType.MakeGenericType(types);

            dynamic queryhandler = _provider.GetService(queryHandlerType);
            return queryhandler.Handle((dynamic)query);
        }

        //services.AddScoped<ICommandHandler<OrderCommand>,OrderCommandHandler>();
        public Result Dispatch(ICommand command)
        {
            var commandHandlerType = typeof(ICommandHandler<>);
            var commandType = command.GetType();
            var typeArgs = new[] { commandType };
            var handlerType = commandHandlerType.MakeGenericType(typeArgs);
            dynamic handler= _provider.GetService(handlerType);
            var result = handler.Handle((dynamic)command);
            return result;
        }





    }
}


