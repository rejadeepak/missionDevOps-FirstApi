using System;
using VSCodeEventBus.Controllers.Misc;
using VSCodeEventBus.Manager;
using VSCodeEventBus.Mapper;


namespace VSCodeEventBus.CQRS
{
    public class OrderCommand : ICommand
    {

        public OrderCommand()
        {

        }

        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

    }

    

    public class OrderCommandHandler : ICommandHandler<OrderCommand>
    {
        private readonly IDataStore _dataStore;
        private readonly IOrderMapper _mapper;
        public OrderCommandHandler(IDataStore dataStore, IOrderMapper mapper )
        {
            _dataStore = dataStore;
            _mapper = mapper;
        }
        public Result Handle(OrderCommand command)
        {
            var order= _mapper.Map(command);
            return _dataStore.AddOrder(order);
        }
    }

}