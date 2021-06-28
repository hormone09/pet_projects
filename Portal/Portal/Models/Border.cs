using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Models
{
    public class Border
    {
        public int id { get; set; }
        public string name { get; set; }
        public Course course { get; set; }
        public List<Subject> subjects { get; set; }
        public List<BorderMark> marks { get; set; }
        public DateTime dateOfBegin { get; set; }
        public DateTime dateOfFinish { get; set; }
        public int numberOfPairs { get; set; }
        public bool IsFinished { get; set; }
        public bool IsNow { get; set; }
    }
}
