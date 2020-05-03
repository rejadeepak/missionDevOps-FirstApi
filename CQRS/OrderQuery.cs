using VSCodeEventBus.Domain;
using VSCodeEventBus.Manager;
using VSCodeEventBus.Mapper;
using VSCodeEventBus.VSCodeEventBus;
using VSCodeEventBus.Handlers;
using System;

namespace VSCodeEventBus.CQRS
{
    public class OrderQuery : IQuery<Order>
    {
        public int orderId { get; set; }
    }

    public class OrderQueryHandler : IQueryHandler<OrderQuery, Order>
    {
        private readonly IDataStore _dataStore;
        private readonly IOrderMapper _mapper;
        private readonly IPubSubEventBus _pubSubEventBus;

        public OrderQueryHandler(IDataStore dataStore, IOrderMapper mapper, IPubSubEventBus pubSubEventBus)
        {
            _dataStore = dataStore;
            _mapper = mapper;
            _pubSubEventBus = pubSubEventBus;
        }

        public Order Handle(OrderQuery query)
        {
            var queryResult = _dataStore.GetOrder(query.orderId);
            if (queryResult != null)
            {
                var orderRetrieveEvent = new OrderRetrieveEvent()
                {
                    OrderId = query.orderId
                };
                _pubSubEventBus.Publish(orderRetrieveEvent);
            }
            return queryResult;
        }



    }
}