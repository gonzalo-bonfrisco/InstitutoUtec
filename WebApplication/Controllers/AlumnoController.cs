using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: AlumnoController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AlumnoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AlumnoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AlumnoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AlumnoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AlumnoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AlumnoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AlumnoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
