using System;
using System.Collections.Generic;

namespace WatchStoreApp.Data.Entities
{
    public partial class Orders
    {
        public Orders()
        {
            CustomerOrder = new HashSet<CustomerOrder>();
        }

        public int Oid { get; set; }
        public int? Cid { get; set; }
        public int? Lid { get; set; }
        public DateTime? OrderTime { get; set; }

        public virtual Customer C { get; set; }
        public virtual Locations L { get; set; }
        public virtual ICollection<CustomerOrder> CustomerOrder { get; set; }
    }
}
