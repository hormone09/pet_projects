using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Models.ViewModels
{
    public class CourseViewModel
    {
        public int courseId;
        public string courseName;
        public string groupName;
        public string teacherName;
        public int numberBorders;
        public Border activeBorder;
        public List<Border> passiveBorders = new List<Border>();
        public Subject subjectToday;
        public int personNumber;
        public List<Student> students;
        public string imgPath;

        public CourseViewModel(Course course, int personNumber, bool IsTeacher)
        {
            var activeBorder = course.borders.FirstOrDefault(x => x.IsNow == true);
            if (IsTeacher)
            {
                students = new List<Student>();
                students.AddRange(course.group.students);
            }
            else
            {
                students = null;
                //var student = course.group.students.Single(x => x.id == personNumber);
                //foreach(var subject in activeBorder.subjects)
                //    for(int i =0; i< subject.answers.Count; i++)
                //    {
                //        if(subject.answers[i].student != student)
                //        {
                //            subject.answers.Remove(subject.answers[i]);
                //        }
                //    }
                
            }
            courseId = course.id;
            if (activeBorder != null)
            {
                var activeSubject = activeBorder.subjects.FirstOrDefault(x => x.IsToday == true);
                if (activeSubject != null)
                {
                    activeBorder.subjects.Remove(activeSubject);
                    course.borders.Remove(activeBorder);
                    subjectToday = activeSubject;
                }
            }
            var passiveBorders = course.borders;

            courseName = course.name;
            if(activeBorder != null)
                this.activeBorder = activeBorder;
            this.passiveBorders = passiveBorders;
            groupName = course.group.name;
            numberBorders = course.numberOfBorders;
            this.personNumber = personNumber;
            if(course.teacher != null)
            {
                teacherName = course.teacher.name + "  " + course.teacher.sename;
                imgPath = course.teacher.imgPath;
            }
            else
                teacherName = "";
        }
    }
}
