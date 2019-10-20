using System;
using System.Collections.Generic;
using System.Text;

namespace WatchStoreApp.Business
{
    public class Customer
    {
        public int CID { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        List<Customer> NumCustomer = new List<Customer>();
        public Customer()
        {

        }
    }
}
