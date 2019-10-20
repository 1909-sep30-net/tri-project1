using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace WatchStoreApp.Models
{
    public class CustomerViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public IEnumerable<CustomerViewModel> AllCustomer { get; set; }
    }
}
