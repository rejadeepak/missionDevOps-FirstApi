using System;
using System.Linq;
using System.Collections.Generic;
using VSCodeEventBus.Domain;
using VSCodeEventBus.Controllers.Misc;


namespace VSCodeEventBus.Manager
{

    public interface IDataStore
    {
        List<Customer> GetCustomers();

        Order GetOrder(int orderId);
        List<Order> GetOrders();

        Result AddOrder(Order order);

        void DeleteOrder(Order order);

        void UpdateOrder(Order order);
    }


    public class DataStore : IDataStore
    {
        public List<Customer> GetCustomers()
        {
            var customers = new List<Customer>();
            var customer = new Customer()
            {
                Id = 100,
                Name = "HAL",
                Email = "hal@google.com",
                Address1 = "XYZ",
                Address2 = "Blore",
                Pincode = "208001"
            };

            customers.Add(customer);

            customer = new Customer()
            {
                Id = 101,
                Name = "GE",
                Email = "ge@google.com",
                Address1 = "ABC",
                Address2 = "Male",
                Pincode = "999001"
            };

            customers.Add(customer);

            return customers;
        }
        public List<Order> GetOrders()
        {
            var orders = new List<Order>();
            var order = new Order()
            {
                Id = 1,
                CustomerId = GetCustomers().FirstOrDefault().Id,
                OrderDate = DateTime.Now.AddDays(-5),
                Price = 60.8M,
                Quantity = 7

            };

            orders.Add(order);
            order = new Order()
            {
                Id = 2,
                CustomerId = GetCustomers().FirstOrDefault().Id,
                OrderDate = DateTime.Now.AddDays(-7),
                Price = 97.6M,
                Quantity = 5

            };
            orders.Add(order);

            order = new Order()
            {
                Id = 3,
                CustomerId = GetCustomers().FirstOrDefault().Id,
                OrderDate = DateTime.Now.AddDays(-7),
                Price = 97.6M,
                Quantity = 5

            };
            orders.Add(order);

            
            order = new Order()
            {
                Id = 4,
                CustomerId = GetCustomers().FirstOrDefault().Id,
                OrderDate = DateTime.Now.AddDays(-7),
                Price = 97.6M,
                Quantity = 5

            };
            
            orders.Add(order);

            return orders;
        }

        public Result AddOrder(Order order)
        {
            GetOrders().Add(order);
            return Result.Ok();
        }

        public void DeleteOrder(Order order)
        {
            GetOrders().Remove(order);

        }

        public void UpdateOrder(Order order)
        {
            var selectedOrders = GetOrders().Where(x => x.Id.Equals(order.Id)).FirstOrDefault();            
            if (selectedOrders != null)
            {
                selectedOrders = order;                               
            }
        }

        public Order GetOrder(int orderId)
        {
            return GetOrders().Where(x => x.Id.Equals(orderId)).FirstOrDefault();     
        }
    }
}