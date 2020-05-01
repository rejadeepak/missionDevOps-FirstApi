using VSCodeEventBus.Domain;
using VSCodeEventBus.Manager;
using VSCodeEventBus.Mapper;

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
        public OrderQueryHandler(IDataStore dataStore, IOrderMapper mapper )
        {
            _dataStore = dataStore;
            _mapper = mapper;
        }

        public Order Handle(OrderQuery query)
        {
           return _dataStore.GetOrder(query.orderId);
        }
    }
}