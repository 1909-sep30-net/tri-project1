using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using Microsoft.EntityFrameworkCore;
using WatchStoreApp.Business.Interface;
using WatchStoreApp.Data.Entities;
using WatchStoreApp.Business;

using WatchStoreApp.Business.Interface;

namespace WatchStoreApp.Data.Repositories
{
    public class CustomerRepo:ICustomerRepository
    {
        private readonly WatchStoreContext MyDBContext; 

        public CustomerRepo(WatchStoreContext myDBContext)
        {
            MyDBContext = myDBContext ?? throw new ArgumentNullException(nameof(myDBContext));

        }

        public IEnumerable<Business.Customer>GetCustomers(string name = null)
        {

            IQueryable<Entities.Customer> customers = MyDBContext.Customer.AsNoTracking();
            if (name != null)
            {
                customers = customers.Where(c => c.Names.Contains(name));
            }
            return customers.Select(Mapper.MapCustomer);
            
        }

        public void AddCustomers(Business.Customer customer)
        {
            //Need to check if customer is already in the database
            //if it is then throw exception
            //will add in later

            Entities.Customer entity = Mapper.MapCustomer(customer);
            MyDBContext.Add(entity);
        }

        public void Save()
        {
            MyDBContext.SaveChanges();
        }

    }
}
