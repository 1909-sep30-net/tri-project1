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

        //Map Entity --> Business
        public static Business.CustomerOrder MapCustomerOrder(Entities.CustomerOrder ECustomerOrder)
        {
            return new Business.CustomerOrder
            {
                OID = ECustomerOrder.Oid,
                PID = ECustomerOrder.Pid,
                Amount = ECustomerOrder.Amount
            };

        }

        //Map Business --> Entity
        public static Entities.CustomerOrder MapCustomerOrder(Business.CustomerOrder BCustomerOrder)
        {
            return new Entities.CustomerOrder
            {
                Oid = BCustomerOrder.OID,
                Pid = BCustomerOrder.PID,
                Amount = BCustomerOrder.Amount
            };
        }

        //Map Entity --> Business
        public static Business.Inventory MapInventory(Entities.Inventory EInventory)
        {
            return new Business.Inventory
            {
                LID = EInventory.Lid,
                PID = EInventory.Pid,
                Quantity = EInventory.Quantity
            };
        }

        //Map Business --> Entity
        public static Entities.Inventory MapInventory(Business.Inventory BInventory)
        {
            return new Entities.Inventory
            {
                Lid = BInventory.LID,
                Pid = BInventory.PID,
                Quantity = BInventory.Quantity
            };
        }

        //Map Entity --> Business
        public static Business.Location MapLocation(Entities.Locations ELocation)
        {
            return new Business.Location
            {
                LID = ELocation.Lid,
                Located = ELocation.Located,
                //More
            };
        }

        //Map Business --> Entity
        public static Entities.Locations MapLocation(Business.Location BLocation)
        {
            return new Entities.Locations
            {
                Lid = BLocation.LID,
                Located = BLocation.Located
            };
        }

        //Map Entity --> Business
        public static Business.Order MapOrder(Entities.Orders EOrder)
        {
            return new Business.Order{
                OID = EOrder.Oid,
                CID = EOrder.Cid,
                LID = EOrder.Lid,
                OrderTime = EOrder.OrderTime
                //More things
            };
        }

        //Map Businesss --> Entity
        public static Entities.Orders MapOrder(Business.Order BOrder)
        {
            return new Entities.Orders
            {
                Oid = BOrder.OID,
                Cid = BOrder.CID,
                Lid = BOrder.LID,
                OrderTime = BOrder.OrderTime
                //More things
            };
        }
    }
}
