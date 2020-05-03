using System;
using System.Diagnostics;
using System.Threading.Tasks;
using VSCodeEventBus.VSCodeEventBus;

namespace VSCodeEventBus.Handlers
{

    public class OrderRetrieveEvent : IntergrationEvent
    {
        public int OrderId { get; set; }
    }


    public class OrderRetrieveEventHandler : IIntergrationEventHandler<OrderRetrieveEvent>
    {
        public void Handle(OrderRetrieveEvent intergationEvent)
        {
            Debug.WriteLine("Haa haaa  Order is retrieved....");
        }
    }


}