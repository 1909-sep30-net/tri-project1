using System;
using System.Collections.Generic;
using System.Text;

using WatchStoreApp.Business;

namespace WatchStoreApp.Business.Interface
{
    //Get all customers
    public interface ICustomerRepository
    {
        //Gets all the customers
        public IEnumerable<Customer> GetCustomers(string name);

        //Gets all orders
        public IEnumerable<Order> GetOrders(string name);

        //Gets all Locations
        public IEnumerable<Location> GetLocations(string name);

        //Get a customer by a specific ID
        public Customer GetCustomerID(int id);

        //Add a customer

        public void AddCustomers(Customer customer);

        //Add an order
        public void AddOrders(Order order);

        //Add a CustomerOrder
        public void AddCustomerOrders(CustomerOrder customerOrder);

        //Updating a customer
        public void UpdateCustomers(Customer customer);

        void Save();
        
        //Should probably add a dispose method and extend IDisposable
    }
}
