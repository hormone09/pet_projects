using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Models.ViewModels
{
    public class NewPersonViewModel
    {
        public string name { get; set; }
        public string sename { get; set; }
        public string email { get; set; }
        public DateTime birthday { get; set; }
        public bool IsTeacher { get; set; }
    }
}
