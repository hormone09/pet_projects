using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Portal.Models;
using Portal.Models.ViewModels;
using Portal.Models.Abstract;
using Portal.Repository;
using Portal.Data;
using Portal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Microsoft.AspNetCore.SignalR;
using Portal.Server;

namespace Portal.Controllers
{
    [Authorize(Roles = "teacher")]
    public class TeacherController : Controller
    {
        private AplicationDbContext db;
        private readonly UserManager<User> userManager;
        private readonly ITeacher iTeacher;
        public TeacherController(AplicationDbContext db, UserManager<User> userManager, ITeacher iTeacher)
        {
            this.db = db;
            this.userManager = userManager;
            this.iTeacher = iTeacher;
        }
        public ViewResult PersonalArea()
        {
            var user = userManager.GetUserAsync(User).GetAwaiter().GetResult();
            var teacher = iTeacher.GetTeacher(user.Id.ToString());
            TeacherPersonalAreViewModel model = new TeacherPersonalAreViewModel(teacher);
            

            return View(model);
        }
        public ViewResult Group()
        {
            var userId = GetUser().Id.ToString();
            var teacher = iTeacher.GetTeacher(userId);
            TeacherGroupViewModel model = new TeacherGroupViewModel(teacher);

            return View(model);
        }
        public ViewResult Course(int courseNumber)
        {
            var userId = userManager.GetUserAsync(User).GetAwaiter().GetResult().Id.ToString();
            var teacher = iTeacher.GetTeacher(userId);
            var course = teacher.courses.Single(x => x.id == courseNumber);
            CourseViewModel model = new CourseViewModel(course, teacher.id, true);

            return View(model);
        }
        public ViewResult StudentAnswers(int subjectNumber)
        {
            AnswersViewModel model = new AnswersViewModel();
            var teacher = iTeacher.GetTeacher(GetUser().Id.ToString());
            var courses = teacher.courses.ToList();
            Course course = new Course();
            foreach(var _course in courses)
                foreach (var border in _course.borders)
                {
                    var currentSubject = border.subjects.SingleOrDefault(x => x.id == subjectNumber);
                    if(currentSubject != null)
                    {
                        model.subject = currentSubject;
                        model.courseName = _course.name;
                        model.groupName = _course.group.name;
                        course = _course;
                    }
                }
            foreach(var student in course.group.students)
            {
                var answer = model.subject.answers.SingleOrDefault(x => x.student == student);
                if(answer != null)
                {
                    model.answers.Add(
                        new StudentWithAnswer
                        {
                            student = student,
                            answer = answer,
                        });
                }
                else
                    model.answers.Add(
                        new StudentWithAnswer
                        {
                            student = student,
                            answer = null,
                        });
            }


            return View(model);
        }
        [HttpPost]
        public RedirectToActionResult AddSchedule(string[][] subjects, TimeSpan[][] time, bool IsNumerator)
        {
            bool result;
            var userId = GetUser().Id.ToString();
            if (IsNumerator)
                result = iTeacher.AddNumerator(subjects, time, userId);
            else
                result = iTeacher.AddDenominator(subjects, time, userId);

            return RedirectToAction("Group");
        }

        [HttpPost]
        [Route("addBorder")]
        public bool AddBorder(int courseNumber, DateTime begin, DateTime finish, int pairs)
        {
            if (begin < DateTime.Now.Date || finish < begin || pairs < 3)
                return false;
            else
            {
                var course = db.courses.SingleOrDefault(x => x.id == courseNumber);
                Border newBorder = new Border
                {
                    course = course,
                    dateOfBegin = begin,
                    dateOfFinish = finish,
                    numberOfPairs = pairs
                };

                int groupId;
                var groups = db.groups.ToList();
                foreach(var group in groups)
                    if(group.courses.Contains(course))
                    {
                        groupId = group.id;
                        var head = "Новый атестационный период";
                        var message = $"Начало: {begin.ToShortDateString()} Итог: {begin.ToShortDateString()}";
                        iTeacher.AddNotificationToGroup(head, message, groupId);
                    }


                

                return iTeacher.AddBorder(courseNumber, newBorder);
            }
        }

        [HttpPost]
        [Route("addSubject")]
        public bool AddSubject(int borderNumber, string heading, string task, TimeSpan timeBegin,
            DateTime dateBegin, DateTime timeForAnswer)
        {
            if (borderNumber == 0 || heading.Length < 7 || String.IsNullOrEmpty(heading) ||
                String.IsNullOrEmpty(task) || task.Length < 7)
                return false;

            else if (dateBegin < DateTime.Now || timeForAnswer < dateBegin 
                || (timeForAnswer - dateBegin).Days < 3)
                return false;

            else
            {
                var currentBorder = db.borders.Single(x => x.id == borderNumber);
                Subject newSubject = new Subject
                {
                    border = currentBorder,
                    heading = heading,
                    task = task,
                    date = dateBegin,
                    time = timeBegin,
                    timeBorderForAnswer = timeForAnswer
                };
                var course = db.courses.Single(x => x.borders.Contains(currentBorder));
                var group = db.groups.Single(x => x.courses.Contains(course));
                iTeacher.AddNotificationToGroup("Назначена пара", $"Предмет: {course.name}", group.id);
                

                return iTeacher.AddSubjectToBorder(borderNumber, newSubject);
            }
        }
        [HttpPost]
        [Route("delete")]
        public bool DeleteSubject(int subjectNumber)
        {
            using (db)
            {
                var subject = db.subjects.SingleOrDefault(x => x.id == subjectNumber);
                if (subject != null)
                {
                    var answers = db.answers.Where(x => x.subject == subject);
                    db.answers.RemoveRange(answers);
                    db.subjects.Remove(subject);
                    db.SaveChanges();

                    return true;
                }
                else 
                    return false;
            }
        }
        [HttpPost]
        [Route("addMark")]
        public bool AddMark(int mark, int studentNumber, int borderNumber = 0, int answerNumber = 0)
        {
            if (mark == 0 || studentNumber == 0)
                return false;

            if (borderNumber != 0)
            {
                return iTeacher.EstimateBorder(mark, studentNumber, borderNumber);
            }
            else if (answerNumber != 0)
            {
                return iTeacher.EstimateSubject(mark, studentNumber, answerNumber);
            }
            else
                return false;
        }
        [HttpGet]
        [Route("teacher-navbar")]
        public string NavbarInfo()
        {
            // Общая информация
            RepGroup repGroup = new RepGroup(db);
            var teacher = iTeacher.GetTeacher(GetUser().Id.ToString());
            string fullName = teacher.name + " " + teacher.sename;
            
            var group = repGroup.GetGroup(teacher);
            string groupName;
            if (group != null)
                groupName = group.name;
            else
                groupName = "Вы не назначены куратором";

            dynamic NavbarJson = new JObject();
            NavbarJson.TeacherName = fullName;
            NavbarJson.GroupName = groupName;

            //Уведомления
            var notifications = db.notifications.Where
                (x => x.personalNumber.ToString().Equals(teacher.numberOfAccount));
            if (notifications == null || notifications.Count() < 1)
                NavbarJson.IsHasNotifications = false;
            else
            {
                NavbarJson.IsHasNotifications = true;
                NavbarJson.Notifications = new JArray() as dynamic;
                NavbarJson.NumbersNotCheckedNotifications =
                    notifications.Where(x => x.IsChecked == true).Count();
                foreach (var el in notifications)
                {
                    dynamic notif = new JObject();
                    notif.Head = el.head;
                    notif.Message = el.message;
                    notif.Time = el.time.ToShortDateString();
                    notif.IsChecked = el.IsChecked;
                    NavbarJson.Notifications.Add(notif);
                }
            }

            var json = JsonConvert.SerializeObject(NavbarJson);

            return json;
        }
        private User GetUser()
        {
            var user = userManager.GetUserAsync(User).GetAwaiter().GetResult();
            return user;
        }
    }
}
