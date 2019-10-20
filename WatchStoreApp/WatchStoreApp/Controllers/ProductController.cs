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
    public class ProductController : Controller
    {
        public IProductRepository Repo { get; }

        public ProductController(IProductRepository repo) =>
              Repo = repo ?? throw new ArgumentNullException(nameof(repo));

        // GET: Product

        //Display all products
        public ActionResult Index([FromQuery]string search ="" )
        {
            IEnumerable<Product> product = Repo.GetProduct(search);
            IEnumerable<ProductViewModel> viewModels = product.Select(p => new ProductViewModel
            {
                //viewModel attributes = business attributes

                ID = p.Id,
                Name  = p.Name,
                Model = p.Model,
                Price = p.Price

            });
            return View(viewModels);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
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

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
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