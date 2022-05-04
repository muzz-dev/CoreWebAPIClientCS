using CoreWebAPIClientCS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CoreWebAPIClientCS.Controllers
{
    public class CourseController : Controller
    {
        private static List<MyCourse> courses = new List<MyCourse>();

        private HttpClient httpClient = new HttpClient();

        private string url = "";

        public CourseController()
        {
            url = @"http://localhost:33365/api/CourseWebAPI";
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // GET: CourseController
        public async Task<ActionResult> Index()
        {
            var msg = await httpClient.GetAsync(url);
            var CourseResponse = msg.Content.ReadAsStringAsync();

            courses = JsonConvert.DeserializeObject<List<MyCourse>>(CourseResponse.Result);

            return View(courses);
        }

        // GET: CourseController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View(await getCourseById(id));
        }

        // GET: CourseController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MyCourse newCourse)
        {
            try
            {
                StringContent courseContent = new StringContent(
                        JsonConvert.SerializeObject(newCourse), Encoding.UTF8, "application/json"
                    );
                var msg = await httpClient.PostAsync("http://localhost:33365/api/CourseWebAPI", courseContent);
                var CourseResponse = msg.Content.ReadAsStringAsync();

                if (CourseResponse.Result.Contains("Conflict"))
                {
                    return RedirectToAction(nameof(Create));
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View(await getCourseById(id));
        }

        // POST: CourseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, MyCourse courseToEdit)
        {
            try
            {
                MyCourse myCourse = await getCourseById(id);
                myCourse.CourseName = courseToEdit.CourseName;

                StringContent courseContent = new StringContent(
                        JsonConvert.SerializeObject(myCourse), Encoding.UTF8, "application/json"
                    );
                var msg = await httpClient.PutAsync(url+"/"+id, courseContent);
                var CourseResponse = msg.Content.ReadAsStringAsync();

                if (CourseResponse.Result.Contains("Conflict"))
                {
                    return RedirectToAction(nameof(Edit),id);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View(await getCourseById(id));
        }

        // POST: CourseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, MyCourse courseToDelete)
        {
            try
            {
                var msg = await httpClient.DeleteAsync(url + "/" + id);
                var CourseResponse = msg.Content.ReadAsStringAsync();

                if (CourseResponse.Result.Contains("Conflict"))
                {
                    return RedirectToAction(nameof(Delete), id);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private async Task<MyCourse> getCourseById(int id)
        {
            var msg = await httpClient.GetAsync(url + "/" + id);
            var CourseResponse = msg.Content.ReadAsStringAsync();

            MyCourse myCourse = JsonConvert.DeserializeObject<MyCourse>(CourseResponse.Result);

            return myCourse;
        }
    }
}
