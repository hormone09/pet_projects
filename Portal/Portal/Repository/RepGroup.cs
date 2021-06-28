using Portal.Data;
using Portal.Models;
using Portal.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Repository
{
    public class RepGroup
    {
        private readonly AplicationDbContext db;
        public RepGroup(AplicationDbContext db)
        {
            this.db = db;
        }

        public List<FinallyMark> GetCourseMarks(int courseId)
        {
            List<FinallyMark> marks = new List<FinallyMark>();
            var currentCourse = db.courses.Single(x => x.id == courseId);
            marks = db.finallyMarks.Where(x => x.course == currentCourse).ToList();

            return marks;
        }
        public Group GetGroup(Teacher teacher)
        {
            Group group = new Group();
            group = db.groups.SingleOrDefault(x => x.curator == teacher);
            
            if(group != null)
            {
                RepCourse courseRep = new RepCourse(db);
                group.curator = GetCurator(group);
                group.courses = courseRep.GetAllCourses(group);
                group.students = GetStudentsByGroup(group);

                group.numeratorSchedule = GetNumerator(group);
                group.denominatorSchedule = GetDenominator(group);
            }

            return group;
        }
        public Group GetGroup(Student student) // TODO: переделать через LINQ
        {
            Group group = new Group();
            var groups = db.groups.ToList();
            bool IsHasGroup = false;

            foreach (var el in groups)
            {
                var students = el.students;
                if (students != null)
                {
                    IsHasGroup = true;
                    foreach (var _student in el.students)
                    {
                        if (_student == student)
                            group = el;
                    };
                }
                else
                    group = null;
            }

            if (IsHasGroup)
            {
                RepCourse courseRep = new RepCourse(db);
                group.curator = GetCurator(group);
                group.courses = courseRep.GetAllCourses(group);
                group.students = GetStudentsByGroup(group);
                group.numeratorSchedule = GetNumerator(group);
                group.denominatorSchedule = GetDenominator(group);
            }

            return group;
        }
        public List<Student> GetStudentsByGroup(int groupId)
        {
            var group = db.groups.Single(x => x.id == groupId);
            return GetStudentsByGroup(group);
        }
        public List<Student> GetStudentsByGroup(Group group)
        {
            List<Student> students = new List<Student>();
            var studentInDb = db.students.Where(x => x.group == group);
            if (studentInDb != null)
            {
                students.AddRange(studentInDb);
                foreach (var el in students)
                    el.group = group;
            }
            else students = null;

            return students;
        }
        private Numerator GetNumerator(Group group)
        {
            Numerator numerator = db.numeratorSchedules.SingleOrDefault
                       (x => x.groupId == group.id);
            if (numerator != null)
                numerator.days = db.schoolDays.
                    Where(x => x.numerator == numerator).ToList();
            return numerator;
        }
        private Denominator GetDenominator(Group group)
        {
            Denominator denominator = db.denominatorSchedules.SingleOrDefault
                       (x => x.groupId == group.id);
            if (denominator != null)
                denominator.days = db.schoolDays.
                    Where(x => x.denominator == denominator).ToList();
            return denominator;
        }
        private Teacher GetCurator(Group group)
        {
            Teacher curator = new Teacher();
            var teacher = db.teachers.SingleOrDefault(x => x.group == group);
            if (teacher != null)
                curator = teacher;
            else curator = null;

            return curator;
        }
    }
}
