using Portal.Data;
using Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Repository
{
    public class RepCourse
    {
        private readonly AplicationDbContext db;
        public RepCourse(AplicationDbContext db)
        {
            this.db = db;
        }

        public List<Course> GetAllCourses(Teacher teacher)
        {
            List<Course> courses = new List<Course>();
            var coursesDb = db.courses.Where(x => x.teacher == teacher).ToList();
            courses.AddRange(coursesDb);

            foreach (var course in courses)
            {
                course.borders = GetBorders(course);
                course.teacher = teacher;
            }

            return courses;
        }
        public List<Course> GetAllCourses(Group group)
        {
            List<Course> courses = new List<Course>();
            var coursesDb = db.courses.Where(x => x.group == group).ToList();
            courses.AddRange(coursesDb);

            foreach (var course in courses)
            {
                course.borders = GetBorders(course);

                course.teacher = db.teachers.SingleOrDefault(x => x == course.teacher);
            }

            return courses;
        }
        public Course GetCourseBySubject(Subject subject)
        {
            var allCourses = db.courses.ToList();
            foreach(var course in allCourses)
            {
                foreach(var border in course.borders)
                {
                    var currentSubject = border.subjects.SingleOrDefault(x => x == subject);
                    if (currentSubject != null)
                        return course;
                }
            }

            return null;
        }
        public List<Subject> GetSubjectsToday(Student student)
        {
            if(student.IsHasGroup)
            {
                var courses = student.group.courses.ToList();
                foreach (var course in courses)
                {
                    var activeBorder = course.borders.SingleOrDefault(x => x.IsNow == true);
                    if (activeBorder != null)
                    {
                        var activeSubjects = activeBorder.subjects.Where(x => x.IsToday == true);
                        if (activeSubjects != null)
                        {
                            return activeSubjects.ToList();
                        }
                    }
                }
            }

            return null;
        }
        private List<Border> GetBorders(Course course)
        {
            List<Border> borders = new List<Border>();
            var bordersInDb = db.borders.Where(x => x.course == course);
            borders.AddRange(bordersInDb);
            foreach(Border border in borders)
            {
                border.marks = new List<BorderMark>();
                border.marks.AddRange(db.borderMarks.Where(x => x.border == border));
                border.subjects = GetCurrentSubjects(border);
            }

            return borders;
        }
        private List<Subject> GetCurrentSubjects(Border border)
        {
            List<Subject> currentSubjects = new List<Subject>();
            var subjectsInDb = db.subjects.Where(x => x.border == border).ToList();

            if (subjectsInDb != null)
            {
                currentSubjects.AddRange(subjectsInDb); 

                foreach (var el in subjectsInDb)
                {
                    el.answers = new List<Answer>();
                    el.answers.AddRange(db.answers.Where(x => x.subject == el));
                    foreach(var answer in el.answers)
                    {
                        var mark = db.answerMarks.SingleOrDefault(x => x.answerId == answer.id);
                        answer.mark = mark;
                    }
                }
            }
            else currentSubjects = null;

            return currentSubjects;
        }

    }
}
