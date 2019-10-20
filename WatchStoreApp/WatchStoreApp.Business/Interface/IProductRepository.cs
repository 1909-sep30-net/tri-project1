using System;
using System.Collections.Generic;
using System.Text;

namespace WatchStoreApp.Business.Interface
{
    public interface IProductRepository
    {
        //gets all products
        public IEnumerable<Product> GetProduct(string name);
    }
}
