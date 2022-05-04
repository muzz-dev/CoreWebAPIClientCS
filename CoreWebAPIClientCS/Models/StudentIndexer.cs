using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CoreWebAPIClientCS.Models
{
    public class StudentIndexer
    {
        private static List<MyStudent> students = new List<MyStudent>();

        private HttpClient httpClient = new HttpClient();

        private string url= "";
        public StudentIndexer()
        {
            url = @"http://localhost:33365/api/StudentWebAPI";
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _ = getStudents();
        }

        private async Task getStudents()
        {
            var msg = await httpClient.GetAsync(url);
            var StudentResponse = msg.Content.ReadAsStringAsync();

            students = JsonConvert.DeserializeObject<List<MyStudent>>(StudentResponse.Result);
        }
        public List<MyStudent> this[string studentName]
        {
            get
            {
                return (from s in students
                       where s.StudentName.StartsWith(studentName)
                       select s).ToList();
            }
        }

        public List<MyStudent> this[int min,int max]
        {
            get
            {
                return (from s in students
                        where s.StudentId > min && s.StudentId < max
                        select s).ToList();
            }
        }
    }
}
