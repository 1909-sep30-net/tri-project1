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
    public class CustomerController : Controller
    {

        public ICustomerRepository Repo { get; }

        public CustomerController(ICustomerRepository repo) =>
              Repo = repo ?? throw new ArgumentNullException(nameof(repo));
        // GET: Customer

        //public 


        //This displays all the customers 
        public ActionResult Index([FromQuery]string search = "")
        {
            IEnumerable<Customer> customers = Repo.GetCustomers(search);
            IEnumerable<CustomerViewModel> viewModels = customers.Select(c => new CustomerViewModel
            {
                //viewModel attributes = business attributes
                Id = c.CID,
                Name = c.Name,
                Address = c.Address,
                Phone = c.Phone
                
            });
            return View(viewModels);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customer/Create

        public ActionResult Create() => View();


        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Name")]CustomerViewModel viewModel)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var customer = new Customer
                    {
                        Name = viewModel.Name,
                        Address = viewModel.Address,
                        Phone = viewModel.Phone
                    };


                    return RedirectToAction(nameof(Index));
                }
                return View(viewModel);
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customer/Edit/5
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

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
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