using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Models.ViewModels
{
    public class TeacherPersonalAreViewModel
    {
        public string fullName;
        public string dateOfBirthday;
        public string groupName;
        public bool IsHasGroup;
        public List<Student> students;
        public List<Course> courses;
        public string imagePath;

        public TeacherPersonalAreViewModel(Teacher teacher)
        {
            imagePath = teacher.imgPath;
            courses = teacher.courses;
            dateOfBirthday = teacher.dateOfBirthday.ToLongDateString();
            fullName = $"{teacher.name}  {teacher.sename}";
            IsHasGroup = teacher.IsHasGroup;
            if (IsHasGroup)
            {
                groupName = teacher.group.name;
                students = teacher.group.students;
            }
        }
    }
}
