using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebAPIClientCS.Models
{
    public class MyStudent
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string Gender { get; set; }
        public string Contact { get; set; }
        public int CourseId { get; set; }
        public string courseName { get; set; }
    }
}
