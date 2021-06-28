using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portal.Models;

namespace Portal.Models.Abstract
{
    public abstract class Schedule
    {
        public int id { get; set; }
        public int groupId { get; set; }
        public const int numbersDay = 6;
        public List<SchoolDay> days { get; set; }
    }

    public class Numerator : Schedule { }
    public class Denominator : Schedule { }
}
