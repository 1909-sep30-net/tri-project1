using System;
using System.Collections.Generic;

namespace WatchStoreApp.Data.Entities
{
    public partial class Inventory
    {
        public int Lid { get; set; }
        public int Pid { get; set; }
        public int Quantity { get; set; }

        public virtual Locations L { get; set; }
        public virtual Product P { get; set; }
    }
}
