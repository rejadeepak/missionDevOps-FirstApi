using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VSCodeEventBus.DTO;
using VSCodeEventBus.Domain;
using VSCodeEventBus.CQRS;
using VSCodeEventBus.Controllers.Misc;

namespace VSCodeEventBus.Controllers
{
    [Route("api/Order")]
    public class OrderController : ControllerBase
    {
        private readonly Dispatcher _dispatcher;
        public OrderController(Dispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpGet("{orderId}", Name = "Order")]
        public async Task<Order> GetOrder(int orderId)
        {
            var orderQuery = new OrderQuery();
            orderQuery.orderId = orderId;
            var order= _dispatcher.Dispatch(orderQuery);

            return await Task.FromResult<Order>(order);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder([FromBody] OrderCommand order)
        {
            var result = _dispatcher.Dispatch(order);
            return await Task.FromResult<OkObjectResult>(Ok(result));

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