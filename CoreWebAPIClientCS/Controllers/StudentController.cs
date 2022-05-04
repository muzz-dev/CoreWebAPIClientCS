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
    public class StudentController : Controller
    {
        private static List<MyStudent> students = new List<MyStudent>();

        private HttpClient httpClient = new HttpClient();

        private string url, courseUrl = "";

        public StudentController()
        {
            url = @"http://localhost:33365/api/StudentWebAPI";
            courseUrl = @"http://localhost:33365/api/CourseWebAPI";
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // GET: StudentController
        public async Task<ActionResult> Index()
        {
            var msg = await httpClient.GetAsync(url);
            var StudentResponse = msg.Content.ReadAsStringAsync();

            students = JsonConvert.DeserializeObject<List<MyStudent>>(StudentResponse.Result);
            return View(students);
        }

        // GET: StudentController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View(await getStudentById(id));
        }

        // GET: StudentController/SearchByCourse
        public async Task<ActionResult> SearchByCourse(int? isSearch)
        {
            if(isSearch != null)
            {
                ViewBag.searchByCourseValues = TempData["searchByCourseValues"];
            }
                List<MyCourse> courses;
                var msg = await httpClient.GetAsync(courseUrl);
                var CourseResponse = msg.Content.ReadAsStringAsync();

                courses = JsonConvert.DeserializeObject<List<MyCourse>>(CourseResponse.Result);

            return View(courses);
        }

        // POST: StudentController/SearchByCourse
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SearchByCourse(int dropdownCourse)
        {
            try
            {
                StringContent studentContent = new StringContent(
                        JsonConvert.SerializeObject(dropdownCourse), Encoding.UTF8, "application/json"
                    );
                var msg = await httpClient.PostAsync(url+"/search/" + dropdownCourse, studentContent);
                var StudentResponse = msg.Content.ReadAsStringAsync();
                students = JsonConvert.DeserializeObject<List<MyStudent>>(StudentResponse.Result);
                //TempData["searchByCourseValues"] = students.ToArray();
                return View(nameof(Index),students);
            }
            catch
            {
                return View();
            }
        }


        // GET: StudentController/SearchByAge
        public ActionResult SearchByContactRange()
        {
            return View();
        }

        // POST: StudentController/SearchByAge
        [HttpPost]
        public async Task<ActionResult> SearchByContactRange(int start,int end)
        {
            var msg = await httpClient.GetAsync(url + "/searchByContact/" + start+"/"+end);
            var StudentResponse = msg.Content.ReadAsStringAsync();
            students = JsonConvert.DeserializeObject<List<MyStudent>>(StudentResponse.Result);
            return View(nameof(Index), students);
        }


        // GET: StudentController/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }


        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MyStudent newStudent)
        {
            try
            {
                StringContent studentContent = new StringContent(
                        JsonConvert.SerializeObject(newStudent), Encoding.UTF8, "application/json"
                    );
                var msg = await httpClient.PostAsync(url, studentContent);
                var StudentResponse = msg.Content.ReadAsStringAsync();
                if (StudentResponse.Result.Contains("Conflict"))
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

        // GET: StudentController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View();
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, IFormCollection collection)
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

        // GET: StudentController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View();
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
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
        private async Task<MyStudent> getStudentById(int id)
        {
            var msg = await httpClient.GetAsync(url + "/" + id);
            var StudentResponse = msg.Content.ReadAsStringAsync();

            MyStudent myStudent = JsonConvert.DeserializeObject<MyStudent>(StudentResponse.Result);

            return myStudent;
        }
    }
}
