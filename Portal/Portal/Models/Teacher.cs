using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portal.Models.ViewModels;

namespace Portal.Models
{
    public sealed class Teacher : AbstractPeople
    {
        public int id { get; set; }
        public Group group { get; set; }
        public List<Course> courses { get; set; }

        public Teacher() { }

        public Teacher(RegisterViewModel model, string personalNumber)
        {
            name = model.name;
            sename = model.sename;
            numberOfAccount = personalNumber;
            dateOfRegister = DateTime.Now.Date;
            dateOfBirthday = model.birthday;
            IsHasGroup = false;
        }
    }
}
