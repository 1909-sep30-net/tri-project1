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

        //Add a customer

        void AddCustomers(Customer customer);

        void Save();
    }
}
