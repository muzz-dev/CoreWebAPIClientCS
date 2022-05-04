using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebAPIClientCS.Models
{
    public class StudentSearch
    {
        public int? studentId { get; set; }
        public string? studentName { get; set; }
        public int? start{ get; set; }
        public int? end { get; set; }
        public int? courseId { get; set; }
    }
}
