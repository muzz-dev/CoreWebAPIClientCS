using CoreWebAPIClientCS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebAPIClientCS.Controllers
{
    public class StudentIndexerController : Controller
    {

        private StudentIndexer si = new StudentIndexer();
        private List<MyStudent> students = new List<MyStudent>();

        // GET: StudentIndexerController
        public ActionResult Index()
        {
            return View();
        }

        // GET: StudentIndexerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StudentIndexerController/Search
        public ActionResult Search()
        {
            return View();
        }

        // POST: StudentIndexerController/Search
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(String txtName)
        {
            try
            {
                students = si[txtName];
                ViewData["students"] = students;
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentIndexerController/SearchByRange
        public ActionResult SearchByRange()
        {
            return View();
        }

        // POST: StudentIndexerController/SearchByRange
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SearchByRange(int min,int max)
        {
            try
            {
                students = si[min,max];
                ViewData["students"] = students;
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentIndexerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StudentIndexerController/Edit/5
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

        // GET: StudentIndexerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StudentIndexerController/Delete/5
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
