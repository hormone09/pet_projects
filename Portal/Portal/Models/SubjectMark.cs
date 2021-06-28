using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portal.Models.Abstract;

namespace Portal.Models
{
    public class SubjectMark : Mark
    {
        public DateTime time { get; set; }
        public int answerId { get; set; }
    }
}
