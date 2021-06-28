using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Models
{
    public class Course
    {
        public int id { get; set; }
        public string name { get; set; }
        public Group group { get; set; }
        public Teacher teacher { get; set; }
        public int numberOfBorders { get; set; }
        public List<Border> borders { get; set; }
        public List<FinallyMark> marks { get; set; }
    }
}
