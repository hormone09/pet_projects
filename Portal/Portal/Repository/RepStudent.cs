using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portal.Interfaces;
using Portal.Repository;
using Portal.Models;
using Portal.Data;

namespace Portal.Repository
{
    public class RepStudent : IStudent
    {
        private readonly AplicationDbContext db;
        public RepStudent(AplicationDbContext db)
        {
            this.db = db;
        }
        public Student GetMinimalStudentInfo(string personalNumber)
        {
            Student student = new Student();
            student = db.students.Single(x => x.numberOfAccount.Equals(personalNumber));

            return student;
        }
        public Student GetStudentPage(string pageNumber)
        {
            var student = db.students.SingleOrDefault(x => x.pageNumber.Equals(pageNumber));
            if (student != null)
            {
                student = GetStudent(student.id);
                return student;
            }
            else
                return null;
        }
        public Student GetStudent(int id)
        {
            Student student = new Student();
            student = db.students.Single(x => x.id == id);
            student.imgPath = GetImagePath(Guid.Parse(student.numberOfAccount));
            if (student.IsHasGroup)
            {
                var repository = new RepGroup(db);
                student.group = repository.GetGroup(student);
                if(student.group.courses != null)
                    student.marks = GetAllMarks(student);
            }

            if (student.IsHasGroup)
            {
                foreach (var course in student.group.courses) //Фильтр, убрать данные других студентов
                {
                    foreach (var border in course.borders)
                    {
                        foreach(var subject in border.subjects)
                        {
                            int[] notNeed = new int[subject.answers.Count()];
                            int num = 0;
                            foreach (var answer in subject.answers)
                            {
                                if (answer.student != student)
                                {
                                    notNeed[num] = answer.id;
                                    num++;
                                }
                            }
                            for(int i=0; i<num; i++)
                            {
                                var answer = subject.answers.First(x => x.id == notNeed[i]);
                                subject.answers.Remove(answer);
                            }
                        }
                    }
                }
            }

            return student;
        }
        public bool AddNewAnswer(string answerText, int studentNumber, int subjectNumber)
        {
            bool result;

            var student = db.students.Single(x => x.id == studentNumber);
            var subject = db.subjects.Single(x => x.id == subjectNumber);
            var answer = db.answers.SingleOrDefault
                (x => x.student == student && x.subject == subject);
            if (answer == null)
            {
                Answer newAnswer = new Answer(answerText, student, subject);
                db.answers.Add(newAnswer);
                db.SaveChanges();

                result = true;
            }
            else
                result = false;

            return result;
        }

        public List<FinallyMark> GetAllMarks(Student student)
        {
            List<FinallyMark> marks = new List<FinallyMark>();
            var courses = student.group.courses;
            double valueOfMark;
            foreach (var course in courses)
            {
                var currentMark = db.finallyMarks.SingleOrDefault(x => x.course == course
                && x.student == student);
                if (currentMark != null)
                    valueOfMark = currentMark.valueOfMark;
                else
                    valueOfMark = 0.00;
                FinallyMark newMark = new FinallyMark
                {
                    course = course,
                    student = student,
                    valueOfMark = valueOfMark
                };
                marks.Add(newMark);
            }

            return marks;
        }
        public string GetImagePath(Guid personNumber)
        {
            var image = db.userImages.SingleOrDefault(x => x.userId.Equals(personNumber));
            if (image != null)
                return (@"/photos/" + image.name);
            else
                return @"/img/user.png";
        }
    }
}
