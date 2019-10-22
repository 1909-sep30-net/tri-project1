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

        public IEnumerable<Business.Order> GetOrders(string name = null)
        {
            IQueryable<Entities.Orders> orders = MyDBContext.Orders.AsNoTracking();
            if(name != null)
            {
                //ToString() be careful
                orders = orders.Where(o => o.Oid.ToString().Contains(name));
            }
            return orders.Select(Mapper.MapOrder);
        }

        //Get all Locations
        public IEnumerable<Business.Location>GetLocations(string name = null)
        {
            IQueryable<Entities.Locations> locations = MyDBContext.Locations.AsNoTracking();
            if(name != null)
            {
                locations = locations.Where(l => l.Located.Contains(name));
            }
            return locations.Select(Mapper.MapLocation);
        }

        //Get Customer by their ID
        public Business.Customer GetCustomerID(int id) => Mapper.MapCustomer(MyDBContext.Customer.Find(id));

        public void AddCustomers(Business.Customer customer)
        {
            //Need to check if customer is already in the database
            //if it is then throw exception
            //will add in later

            Entities.Customer entity = Mapper.MapCustomer(customer);
            MyDBContext.Add(entity);
            MyDBContext.SaveChanges();
        }

        public void AddOrders(Business.Order order)
        {
            Entities.Orders entity = Mapper.MapOrder(order);
            MyDBContext.Add(entity);
            MyDBContext.SaveChanges();
        }

        public void AddCustomerOrders(Business.CustomerOrder customerOrder)
        {
            Entities.CustomerOrder entity = Mapper.MapCustomerOrder(customerOrder);
            MyDBContext.Add(entity);
            MyDBContext.SaveChanges();
        }

        //Editing or updating customer
        public void UpdateCustomers(Business.Customer customer)
        {
            Entities.Customer currentEntity = MyDBContext.Customer.Find(customer.CID);
            Entities.Customer newEntity = Mapper.MapCustomer(customer);

            MyDBContext.Entry(currentEntity).CurrentValues.SetValues(newEntity);
            //
            MyDBContext.SaveChanges();
        }

        public void Save()
        {
            MyDBContext.SaveChanges();
        }

    }
}
