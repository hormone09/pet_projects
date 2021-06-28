using System;
using Portal.Interfaces;
using Portal.Repository;
using Portal.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portal.Data;
using Portal.Models.Abstract;
using Portal.Server;
using Microsoft.AspNetCore.SignalR;

namespace Portal.Repository
{
    public class RepTeacher : ITeacher
    {
        private readonly AplicationDbContext db;
        private readonly IHubContext<NotificationHub> hubContext;
        public RepTeacher(AplicationDbContext db, IHubContext<NotificationHub> hubContext)
        {
            this.hubContext = hubContext;
            this.db = db;
        }

        public Teacher GetTeacher(int id)
        {
            var teacherPersonalNumber = db.teachers.Single(x => x.id == id).numberOfAccount;
            var teacher = GetTeacher(teacherPersonalNumber);

            return teacher;
        }
        public Teacher GetTeacher(string personalNumber)
        {
            Teacher teacher = new Teacher();
            teacher = db.teachers.Single(x => x.numberOfAccount.Equals(personalNumber));

            RepGroup repGroup = new RepGroup(db);
            RepCourse courseRep = new RepCourse(db);
            teacher.group = repGroup.GetGroup(teacher);
            teacher.courses = courseRep.GetAllCourses(teacher);
            teacher.imgPath = GetImagePath(Guid.Parse(personalNumber));

            return teacher;
        }
        public bool AddNumerator(string[][] subjects, TimeSpan[][] time, string userId)
        {
            //Validate
            for (int i = 0; i < 6; i++)
                for (int j = 0; j < 3; j++)
                    if (String.IsNullOrEmpty(subjects[i][j]))
                        return false;

            string[] nameOfDays = { "Понедельник", "Ворник", "Среда", "Четверг", "Пятница", "Суббота" };
            var groupId = GetTeacher(userId).group.id;
            Numerator numerator = new Numerator
            {
                groupId = groupId
            };
            List<SchoolDay> newDays = new List<SchoolDay>();

            for (int i = 0; i < 6; i++)
            {
                SchoolDay newDay = new SchoolDay()
                {
                    name = nameOfDays[i],
                    numerator = numerator,
                    denominator = null,
                    firstCourseName = subjects[i][0],
                    secondCourseName = subjects[i][1],
                    thirdCourseName = subjects[i][2],

                    firstTime = time[i][0].ToString(),
                    secondTime = time[i][1].ToString(),
                    thirdTime = time[i][2].ToString()
                };

                newDays.Add(newDay);
            }

            db.schoolDays.AddRange(newDays);
            AddNotificationToGroup("Новое расписание!", "Изменения в знаменателе", groupId).GetAwaiter();
            
            return true;
        }
        public bool AddDenominator(string[][] subjects, TimeSpan[][] time, string userId)
        {
            //Validate
            for (int i = 0; i < 6; i++)
                for (int j = 0; j < 3; j++)
                    if (String.IsNullOrEmpty(subjects[i][j]))
                        return false;

            var groupId = GetTeacher(userId).group.id;
            Denominator denominator = new Denominator
            {
                groupId = 2
            };
            db.denominatorSchedules.Add(denominator);
            List<SchoolDay> newDays = new List<SchoolDay>();

            for (int i = 0; i < 6; i++)
            {
                SchoolDay newDay = new SchoolDay()
                {
                    denominator = denominator,
                    numerator = null,
                    firstCourseName = subjects[i][0],
                    secondCourseName = subjects[i][1],
                    thirdCourseName = subjects[i][2],

                    firstTime = time[i][0].ToString(),
                    secondTime = time[i][1].ToString(),
                    thirdTime = time[i][2].ToString()
                };

                newDays.Add(newDay);
            }

            AddNotificationToGroup("Новое расписание!", "Изменения в знаменателе", groupId).GetAwaiter();
            

            db.schoolDays.AddRange(newDays);
            return true;
        }
        public bool AddSubjectToBorder(int borderNumber, Subject newSubject)
        {
            using (db)
            {
                var border = db.borders.Single(x => x.id == borderNumber);
                newSubject.border = border;
                db.subjects.Add(newSubject);
                db.SaveChanges();
            }

            return true;
        }
        public bool AddBorder(int courseNumber, Border newBorder)
        {
            using (db)
            {
                var course = db.courses.Single(x => x.id == courseNumber);
                newBorder.course = course;
                db.borders.Add(newBorder);
                db.SaveChanges();
            }

            return true;
        }
        public bool EstimateBorder(int valueOfMark, int borderId, int studentId)
        {
            using (db)
            {
                var student = db.students.Single(x => x.id == studentId);
                var border = db.borders.Single(x => x.id == borderId);
                BorderMark newMark = new BorderMark
                {
                    border = border,
                    student = student,
                    valueOfMark = valueOfMark
                };
                db.borderMarks.Add(newMark);
                AddNotification("Атестация", $"Оценка: {valueOfMark}", student.numberOfAccount).GetAwaiter();
            }

            return true;
        }
        public bool EstimateSubject(int valueOfMark, int studentId, int answerId)
        {
            using (db)
            {
                var student = db.students.Single(x => x.id == studentId);
                
                SubjectMark newMark = new SubjectMark
                {
                    student = student,
                    answerId = answerId,
                    time = DateTime.Now,
                    valueOfMark = valueOfMark
                };

                db.answerMarks.Add(newMark);
                AddNotification("Задание оцененно", $"Оценка: {valueOfMark}", student.numberOfAccount).GetAwaiter();
            }
            return true;
        }
        public async Task AddNotification(string head, string message, string personalNumber)
        {
            Notification notification = new Notification(head, message, personalNumber);
            db.notifications.Add(notification);
            db.SaveChanges();

            var user = db.Users.Single(x => x.Id.ToString().Equals(personalNumber));
            var connection =  NotificationHub.FindConnectionString(user.UserName);
            if(connection != null)
                await hubContext.Clients.Client(connection).SendAsync("NewNotification", head, message);
        }
        public async Task AddNotificationToGroup(string head, string message, int groupNumber)
        {
            RepGroup rep = new RepGroup(db);
            var students = rep.GetStudentsByGroup(groupNumber);
            List<Notification> notifications = new List<Notification>();
            foreach(var student in students)
            {
                var number = student.numberOfAccount;
                Notification notification = new Notification(head, message, number);
                notifications.Add(notification);

                var user = db.Users.Single(x => x.Id.ToString().Equals(student.numberOfAccount));
                var connection = NotificationHub.FindConnectionString(user.UserName);
                if (connection != null)
                    await hubContext.Clients.Client(connection)
                        .SendAsync("NewNotification", head, message);
            }

            db.notifications.AddRange(notifications);
            db.SaveChanges();
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
