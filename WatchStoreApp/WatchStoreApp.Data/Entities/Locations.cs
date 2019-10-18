using System;
using System.Collections.Generic;

namespace WatchStoreApp.Data.Entities
{
    public partial class Locations
    {
        public Locations()
        {
            Inventory = new HashSet<Inventory>();
            Orders = new HashSet<Orders>();
        }

        public int Lid { get; set; }
        public string Located { get; set; }

        public virtual ICollection<Inventory> Inventory { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
