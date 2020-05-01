
using System;
using VSCodeEventBus.CQRS;
using VSCodeEventBus.Domain;

namespace VSCodeEventBus.Mapper
{
    public class OrderMapper :IOrderMapper
    {

        public OrderMapper()
        {

        }


        public Order Map(OrderCommand order)
        {            
            return new Order()
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                Price = order.Price,
                Quantity = order.Quantity,
                CustomerId = order.CustomerId

            };
        }

       
    }
}