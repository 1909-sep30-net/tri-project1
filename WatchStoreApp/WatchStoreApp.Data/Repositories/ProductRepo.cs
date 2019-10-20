using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using Microsoft.EntityFrameworkCore;
using WatchStoreApp.Business.Interface;
using WatchStoreApp.Data.Entities;
using WatchStoreApp.Business;

namespace WatchStoreApp.Data.Repositories
{
    public class ProductRepo : IProductRepository
    {
        private readonly WatchStoreContext MyDBContext;

        public ProductRepo(WatchStoreContext myDBContext)
        {
            MyDBContext = myDBContext ?? throw new ArgumentNullException(nameof(myDBContext));

        }

        //Get all Products
        public IEnumerable<Business.Product> GetProduct(string name = null)
        {
            //MyDBContext seems to be returning null

            IQueryable<Entities.Product> product = MyDBContext.Product.AsNoTracking();
            if (name != null)
            {
                product = product.Where(p => p.Names.Contains(name));
            }
            return product.Select(Mapper.MapProduct);
        }


    }
}
