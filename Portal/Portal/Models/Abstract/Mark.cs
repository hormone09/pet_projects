using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Models.Abstract
{
    public abstract class Mark
    {
        public int id { get; set; }
        public double valueOfMark { get; set; }
        public Student student { get; set; }
    }
}
