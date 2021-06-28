using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Models.ViewModels
{
    public class PersonViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string groupName { get; set; }
        public int coursesCount { get; set; }

        public PersonViewModel(Student student)
        {
            id = student.id;
            name = $"{student.name} {student.sename}";
            age = (DateTime.Now.Year - student.dateOfBirthday.Year);
            if(student.IsHasGroup == true)
            {
                groupName = student.group.name;
                coursesCount = student.group.courses.Count();
            }
            else
            {
                groupName = "Нет";
            }
        }
    }
}
