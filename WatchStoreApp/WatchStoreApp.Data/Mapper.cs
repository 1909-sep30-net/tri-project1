using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
namespace WatchStoreApp.Data
{
    public static class Mapper
    {

        //Map Entity --> Business
        public static Business.Customer MapCustomer(Entities.Customer ECustomer)
        {
            return new Business.Customer
            {
                CID = ECustomer.Cid,
                Name = ECustomer.Names,
                Address = ECustomer.Addresses,
                Phone = ECustomer.Phone
                //
            };
        }

        //Map Business --> Entity
        public static Entities.Customer MapCustomer(Business.Customer BCustomer)
        {
            return new Entities.Customer
            {
                Cid = BCustomer.CID,
                Names =BCustomer.Name,
                Addresses = BCustomer.Address,
                Phone = BCustomer.Phone
            };
        }

        //Map Entity -->Business
        public static Business.Product MapProduct(Entities.Product EProduct)
        {
            return new Business.Product
            {
                Id = EProduct.Pid,
                Name = EProduct.Names,
                Model = EProduct.Model,
                Price = EProduct.Price
            };
        }

        //Map Business --> Entity
        public static Entities.Product MapProduct(Business.Product BProduct)
        {
            return new Entities.Product
            {
                Pid = BProduct.Id,
                Names = BProduct.Name,
                Model = BProduct.Model,
                Price = BProduct.Price
            };
        }
    }
}
