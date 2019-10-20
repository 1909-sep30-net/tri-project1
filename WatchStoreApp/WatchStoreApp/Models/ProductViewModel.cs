using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;


namespace WatchStoreApp.Models
{
    public class ProductViewModel
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public int Price { get; set; }

        public string Model { get; set; }
    }
}
