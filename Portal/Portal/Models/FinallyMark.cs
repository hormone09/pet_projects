using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portal.Models.Abstract;

namespace Portal.Models
{
    public class FinallyMark : Mark
    {
        public Course course { get; set; }
    }
}
