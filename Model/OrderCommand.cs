using System;
using System.Linq;
using System.Collections.Generic;
using VSCodeEventBus.Manager;

namespace VSCodeEventBus.Model
{
    public class OrderCommand
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

}