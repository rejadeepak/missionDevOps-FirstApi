using VSCodeEventBus.Model;
using System;
using System.Linq;
using System.Collections.Generic;
using VSCodeEventBus.Domain;

namespace VSCodeEventBus.Manager
{

    public interface IDataStore
    {
        List<Customer> GetCustomers();
        List<OrderCommand> GetOrders();

        void AddOrder(OrderCommand order);

        void DeleteOrder(OrderCommand order);

        void UpdateOrder(OrderCommand order);
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
        public List<OrderCommand> GetOrders()
        {
            var orders = new List<OrderCommand>();
            var order = new OrderCommand()
            {
                Id = 1,
                CustomerId = GetCustomers().FirstOrDefault().Id,
                OrderDate = DateTime.Now.AddDays(-5),
                Price = 60.8M,
                Quantity = 7

            };

            orders.Add(order);
            order = new OrderCommand()
            {
                Id = 2,
                CustomerId = GetCustomers().FirstOrDefault().Id,
                OrderDate = DateTime.Now.AddDays(-7),
                Price = 97.6M,
                Quantity = 5

            };
            orders.Add(order);

            order = new OrderCommand()
            {
                Id = 3,
                CustomerId = GetCustomers().FirstOrDefault().Id,
                OrderDate = DateTime.Now.AddDays(-7),
                Price = 97.6M,
                Quantity = 5

            };
            orders.Add(order);

            
            order = new OrderCommand()
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

        public void AddOrder(OrderCommand order)
        {
            GetOrders().Add(order);
        }

        public void DeleteOrder(OrderCommand order)
        {
            GetOrders().Remove(order);

        }

        public void UpdateOrder(OrderCommand order)
        {
            var selectedOrders = GetOrders().Where(x => x.Id.Equals(order.Id)).FirstOrDefault();

            if (selectedOrders != null)
            {
                selectedOrders = order;
                // GetCustomers().ToList().IndexOf(order);
            }
        }
    }
}