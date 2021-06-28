using Portal.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Models
{
    public class Group
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<Student> students { get; set; }
        public List<Course> courses { get; set; }
        public Teacher curator { get; set; } 
        public int curatorId { get; set; }
        public bool IsNowNumerator { get; set; }
        public Numerator numeratorSchedule { get; set; }
        public Denominator denominatorSchedule { get; set; }
    }
}
