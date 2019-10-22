using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc.ModelBinding;
using WatchStoreApp.Business.Interface;
using WatchStoreApp.Business;
using WatchStoreApp.Models;

namespace WatchStoreApp.Controllers
{
    public class OrderController : Controller
    {

        public ICustomerRepository Repo { get; }

        public OrderController(ICustomerRepository repo) =>
              Repo = repo ?? throw new ArgumentNullException(nameof(repo));

        // GET: Order
        public ActionResult Index([FromQuery]string search ="")
        {
            IEnumerable<Order> orders = Repo.GetOrders(search);
            IEnumerable<OrderViewModel> viewModels = orders.Select(o => new OrderViewModel
            {
                OID = o.OID,
                CID = o.CID,
                LID = o.LID,
                OrderTime = o.OrderTime
                
            });

            return View(viewModels);
        }

        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //GET: CustomerOrder Order/Create
        public ActionResult Create2()
        {
            return View();
        }

        //POST: CustomerORder Order/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create2(CustomerOrderViewModel viewModel)
        {
            try
            {
                var customerOrder = new CustomerOrder
                {
                    OID = viewModel.OID,
                    PID = viewModel.PID,
                    Amount = viewModel.Amount
                };

                Repo.AddCustomerOrders(customerOrder);
                Repo.Save();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }

        }


        // GET: Order/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderViewModel viewModel)
        {
            try
            {
                var order = new Order
                {
                    OID = viewModel.OID,
                    CID = viewModel.CID,
                    LID = viewModel.LID,
                    OrderTime = viewModel.OrderTime
                    //Might have to d something with the DateTime.Now
                };
                Repo.AddOrders(order);
                Repo.Save();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Order/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Order/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}