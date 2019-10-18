using System;
using System.Collections.Generic;

namespace WatchStoreApp.Data.Entities
{
    public partial class Product
    {
        public Product()
        {
            CustomerOrder = new HashSet<CustomerOrder>();
            Inventory = new HashSet<Inventory>();
        }

        public int Pid { get; set; }
        public string Names { get; set; }
        public int Price { get; set; }
        public string Model { get; set; }

        public virtual ICollection<CustomerOrder> CustomerOrder { get; set; }
        public virtual ICollection<Inventory> Inventory { get; set; }
    }
}
