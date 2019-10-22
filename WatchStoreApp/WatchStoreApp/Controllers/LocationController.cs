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
    public class LocationController : Controller
    {

        public ICustomerRepository Repo { get; }

        public LocationController(ICustomerRepository repo) =>
              Repo = repo ?? throw new ArgumentNullException(nameof(repo));
        // GET: Location
        public ActionResult Index([FromQuery]string search ="")
        {
            IEnumerable<Location> locations = Repo.GetLocations(search);
            IEnumerable<LocationViewModel> viewModels = locations.Select(l => new LocationViewModel
            {
                LID = l.LID,
                Located = l.Located
            });
            return View(viewModels);
        }

        // GET: Location/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Location/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Location/Create
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

        // GET: Location/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Location/Edit/5
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

        // GET: Location/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Location/Delete/5
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