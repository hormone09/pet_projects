using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portal.Models.Abstract;

namespace Portal.Models.ViewModels
{
    public class TeacherGroupViewModel
    {
        public string groupName;
        public int numbersStudents;
        public List<Student> students;
        public Numerator numerator;
        public Denominator denominator;
        public bool IsHasGroup;
        public bool IsGroupHasShledue;
        public string[] nameOfDays = { "Понедельник", "Ворник", "Среда", "Четверг", "Пятница", "Суббота"};

        public TeacherGroupViewModel(Teacher teacher)
        {
            IsHasGroup = teacher.group != null;
            if (IsHasGroup)
            {
                groupName = teacher.group.name;
                numbersStudents = teacher.group.students.Count();
                students = teacher.group.students;

                IsGroupHasShledue = teacher.group.numeratorSchedule != null
                    && teacher.group.denominatorSchedule != null;
                if (IsGroupHasShledue)
                {
                    numerator = teacher.group.numeratorSchedule;
                    denominator = teacher.group.denominatorSchedule;
                }
            }
            else
                IsGroupHasShledue = false;
        }
    }
}
