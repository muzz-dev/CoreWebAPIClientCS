using CoreWebAPIClientCS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CoreWebAPIClientCS.Controllers
{
    public class AdvSearchController : Controller
    {
        private static List<MyStudent> students = new List<MyStudent>();

        private HttpClient httpClient = new HttpClient();

        private string url, courseUrl = "";

        public AdvSearchController()
        {
            url = @"http://localhost:33365/api/StudentWebAPI";
            courseUrl = @"http://localhost:33365/api/CourseWebAPI";
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // GET: AdvSearchController
        public async Task<ActionResult> Index()
        {
            var msg = await httpClient.GetAsync(url);
            var StudentResponse = msg.Content.ReadAsStringAsync();

            students = JsonConvert.DeserializeObject<List<MyStudent>>(StudentResponse.Result);
            return View(students);
        }

        // GET: AdvSearchController/Search
        public ActionResult Search()
        {
            return View();
        }

        // POST: AdvSearchController/Search
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(StudentSearch student)
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
