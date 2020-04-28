
using System;
using VSCodeEventBus.DTO;
using VSCodeEventBus.Model;
namespace VSCodeEventBus.Mapper
{
    public class OrderMapper
    {

        public OrderMapper()
        {

        }
        public OrderDto From(OrderCommand order)
        {
            return new OrderDto()
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