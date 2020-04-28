
using System;
using System.Collections.Generic;
using System.Linq;

namespace VSCodeEventBus.DTO
{

  
public class OrderDto
    {
       
        public OrderDto()
        {

        }
        
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public List<Link> Links { get; set; }
       
    }
    
}