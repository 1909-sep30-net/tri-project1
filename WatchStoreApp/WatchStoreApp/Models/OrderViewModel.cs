using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WatchStoreApp.Models
{
    public class OrderViewModel
    {

        public int OID { get; set; }

        public int? CID { get; set; }

        public int? LID { get; set; }

        public DateTime? OrderTime { get; set; }
    }
}
