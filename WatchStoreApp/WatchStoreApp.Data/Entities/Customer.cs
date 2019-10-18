using System;
using System.Collections.Generic;

namespace WatchStoreApp.Data.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Orders>();
        }

        public int Cid { get; set; }
        public string Names { get; set; }
        public string Addresses { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
