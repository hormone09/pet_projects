using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portal.Models.ViewModels;

namespace Portal.Models
{
    public sealed class Student : AbstractPeople
    {
        public int id { get; set; }
        public string speciality { get; set; }
        public Group group { get; set; }
        public List<Answer> answers { get; set; }
        public List<FinallyMark> marks { get; set; }
        public string pageNumber { get; set; }

        public Student() { }

        public Student(RegisterViewModel model, string personalNumber)
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
