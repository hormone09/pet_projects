using Portal.Models;
using Portal.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Models.ViewModels
{
    public class PersonalAreaViewModel
    {
        public string studentName;
        public bool IsHasGroup;
        public string groupName;
        public string dayOfBirthday;
        public List<CourseView> courses;
        public Numerator numerator;
        public Denominator denominator;
        public string imagePath;

        public PersonalAreaViewModel(Student student)
        {
            imagePath = student.imgPath;
            studentName = student.name + "  " + student.sename;
            dayOfBirthday = student.dateOfBirthday.ToLongDateString();

            if (student.IsHasGroup == true)
            {
                groupName = student.group.name;
                IsHasGroup = student.IsHasGroup;
                numerator = student.group.numeratorSchedule;
                denominator = student.group.denominatorSchedule;

                courses = new List<CourseView>();
                if (student.group.courses != null)
                {
                    foreach (var studentCourse in student.group.courses)
                    {
                        CourseView courseView = new CourseView
                        {
                            activBorder = studentCourse.borders.FirstOrDefault(x => x.IsNow == true),
                            finishedBorders = studentCourse.borders.Where(x => x.IsFinished == true).ToList(),
                            teacher = studentCourse.teacher,
                            name = studentCourse.name,
                            id = studentCourse.id
                        };
                        courses.Add(courseView);
                    }
                }
            }
            else
                IsHasGroup = false;
        }
    }

    public struct CourseView
    {
        public int id;
        public string name;
        public Border activBorder;
        public List<Border> finishedBorders;
        public Teacher teacher;
    }
}
