using System;
using System.Collections.Generic;
using System.Text;

namespace WatchStoreApp.Business
{
    public class Order
    {
        public int OID { get; set; }

        public int? CID { get; set; }

        public int? LID { get; set; }

        public DateTime? OrderTime { get; set; }

        //More things
    }
}
