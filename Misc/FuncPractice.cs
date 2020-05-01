using System;
namespace VSCodeEventBus.Controllers.Misc
{
    public class FuncPractice
    {
        Student ss = new Student();

        public void Test()
        {
            ss.Where((x) => x.Id > 0, ()=>ss);
        }
    }


    public class Entity<T> where T : class
    {

        public bool Where(Func<T, bool> funcEntity, Func<T> funcT)
        {

            return funcEntity(funcT());
        }

       
    }

    public class Student : Entity<Student>
    {
        public Student() : base()
        {

        }
        public int Id { get; set; }
    }


}




        // [HttpGet(Name = "Order")]
        // public async Task<OrderCommand> GetOrder([FromRoute] int orderId)
        // {
        //     var order = _dataStore.GetOrders()
        //                 .Where(x => x.Id == orderId)
        //                 .FirstOrDefault();

        //     return await Task.FromResult<OrderCommand>(order);
        // }

        // [Route("CustomerOrders" , Name = "OrdersByCustomer")]

        // public async Task<IEnumerable<OrderCommand>> GetOrdersByCustomer([FromQuery] OrderParameter orderParameter)
        // {
        //     var orders = _dataStore.GetOrders()
        //                 .Where(x => x.CustomerId == orderParameter.CustomerId)
        //                 .Skip((orderParameter.PageNumber - 1) * orderParameter.PageSize)
        //                 .Take(orderParameter.PageSize);
        //     return await Task.FromResult<IEnumerable<OrderCommand>>(orders);
        // }


        // [HttpPost]
        // public async Task<ActionResult<OrderDto>> AddOrder([FromBody] OrderCommand order)//TODO replace with Command //TODO Make Readonly Property
        // {
        //     _dataStore.AddOrder(order);
        //     var orderDto = _orderMapper.From(order);
        //     orderDto.Links = CreateLinksForOrder(orderDto.Id);
        //     return await Task.FromResult<OrderDto>(orderDto);

        // }
