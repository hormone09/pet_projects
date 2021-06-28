using Portal.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Models
{
    public abstract class AbstractPeople
    {
        public string numberOfAccount { get; set; }
        public string name { get; set; }
        public string sename { get; set; }
        public DateTime dateOfRegister { get; set; }
        public DateTime dateOfBirthday { get; set; }
        public bool IsHasGroup { get; set; }
        public string imgPath { get; set; }
    }
}
