using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portal.Models.Abstract;

namespace Portal.Models
{
    public class SchoolDay
    {
        public int id { get; set; }
        public string name { get; set; }
        public string firstCourseName { get; set; }
        public string secondCourseName { get; set; }
        public string thirdCourseName { get; set; }
        public string firstTime { get; set; }
        public string secondTime { get; set; }
        public string thirdTime { get; set; }
        public Numerator numerator { get; set; }
        public Denominator denominator { get; set; }
    }
}
