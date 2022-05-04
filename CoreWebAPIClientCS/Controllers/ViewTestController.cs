using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebAPIClientCS.Controllers
{
    public class ViewTestController : Controller
    {

        public ActionResult ViewString()
        {
            string data = "Show your books.";
            return View(nameof(ViewString), data);
        }

        public ActionResult ViewString2()
        {
            string data = "Please purchase goods.";
            return View(nameof(ViewString), data);
        }

        public ActionResult ViewTuple()
        {
            var data = Tuple.Create<int, string, float>(1, "ICT", 15.8f);
            return View("TupleView", data);
        }

        public ActionResult ViewTupleCollection()
        {
            List<Tuple<int, string, float>> list = new List<Tuple<int, string, float>>();
            list.Add(new Tuple<int, string, float>(1, "I.C.T.", 18.6f));
            list.Add(new Tuple<int, string, float>(2, "I.T.", 85.6f));
            var data = list;
            return View("ViewTupleCollection", data);
        }

        // GET: ViewTestController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ViewTestController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ViewTestController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ViewTestController/Create
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

        // GET: ViewTestController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ViewTestController/Edit/5
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

        // GET: ViewTestController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ViewTestController/Delete/5
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
