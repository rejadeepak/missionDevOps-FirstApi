using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VSCodeEventBus.Manager;
using VSCodeEventBus.Model;
using VSCodeEventBus.Mapper;
using VSCodeEventBus.DTO;
using System.Net.Http;
using VSCodeEventBus.ResourceParameter;
using VSCodeEventBus.Infrastructure;

namespace VSCodeEventBus.Controllers
{
    [Route("api/Order")]
    public class OrderController : ControllerBase
    {
        private readonly IDataStore _dataStore;
        private readonly OrderMapper _orderMapper;
        public OrderController(IDataStore dataStore, OrderMapper orderMapper)
        {
            _dataStore = dataStore;
            _orderMapper = orderMapper;
        }
        [HttpGet("api",Name = "Orders")]
        public async Task<IEnumerable<OrderCommand>> GetOrder() => await Task.FromResult<IEnumerable<OrderCommand>>(_dataStore.GetOrders());

        [HttpGet(Name = "Order")]
        public async Task<OrderCommand> GetOrder([FromRoute] int orderId)
        {
            var order = _dataStore.GetOrders()
                        .Where(x => x.Id == orderId)
                        .FirstOrDefault();

            return await Task.FromResult<OrderCommand>(order);
        }

        [Route("CustomerOrders" , Name = "OrdersByCustomer")]
        //[OrderConActionFilter]
        public async Task<IEnumerable<OrderCommand>> GetOrdersByCustomer([FromQuery] OrderParameter orderParameter)
        {
            var orders = _dataStore.GetOrders()
                        .Where(x => x.CustomerId == orderParameter.CustomerId)
                        .Skip((orderParameter.PageNumber - 1) * orderParameter.PageSize)
                        .Take(orderParameter.PageSize);
            return await Task.FromResult<IEnumerable<OrderCommand>>(orders);
        }


        [HttpPost]
        public async Task<ActionResult<OrderDto>> AddOrder([FromBody] OrderCommand order)//TODO replace with Command //TODO Make Readonly Property
        {
            _dataStore.AddOrder(order);
            var orderDto = _orderMapper.From(order);
            orderDto.Links = CreateLinksForOrder(orderDto.Id);
            return await Task.FromResult<OrderDto>(orderDto);

        }

        private List<Link> CreateLinksForOrder(int orderId)
        {
            List<Link> links = new List<Link>();
            var link = new Link(Url.Link("Order", orderId), "httpGet", "Self");
            links.Add(link);
            link = new Link(Url.Link("Orders", orderId), "httpGet", "Self");
            links.Add(link);
            return links;
        }

    }
}