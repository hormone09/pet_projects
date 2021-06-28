using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Portal.Data;
using Portal.Models;
using Portal.Interfaces;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Portal.Repository;
using Portal.Models.ViewModels;
using System;

namespace Portal.Controllers
{
    [Authorize(Roles = "student")]
    public class StudentController : Controller
    {
        private IStudent iStudent;
        private AplicationDbContext db;
        private readonly UserManager<User> userManager;

        public StudentController(UserManager<User> userManager, AplicationDbContext db, 
            IStudent iStudent)
        {
            this.db = db;
            this.userManager = userManager;
            this.iStudent = iStudent;
        }
        
        public ViewResult PersonalArea()
        {
            var student = GetStudentInfo();
            student = iStudent.GetStudent(student.id);
            PersonalAreaViewModel model = new PersonalAreaViewModel(student);
            ViewBag.NumberSubjects = 0; 
            ViewBag.NumberAnswers = 0;
            ViewBag.NumberCourses = 0;
            if (student.IsHasGroup)
            {
                ViewBag.NumberCourses = student.group.courses.Count;
                foreach (var course in student.group.courses)
                {
                    var activeBorder = course.borders.SingleOrDefault(x => x.IsNow == true);
                    if (activeBorder != null)
                    {
                        ViewBag.NumberSubjects += activeBorder.subjects.Count();
                        foreach (var subject in activeBorder.subjects)
                        {
                            if (subject.answers.Count > 0)
                                ViewBag.NumberAnswers++;
                        }
                    }
                }
            }


            return View(model);
        }

        public ViewResult Course(int courseNumber)
        {
            var studentInfo = GetStudentInfo();
            RepGroup groupRep = new RepGroup(db);
            var courses = iStudent.GetStudent(studentInfo.id).group.courses;
            var course = courses.Single(x => x.id == courseNumber);
            CourseViewModel model = new CourseViewModel(course, studentInfo.id, false);
            if(model.activeBorder != null)
                ViewBag.Subjects = model.activeBorder.subjects;
            return View(model);
        }

        [HttpPost]
        [Route("addAnswer")]
        public bool AddNewAnswer(string answerText, int studentNumber, int subjectNumber)
        {
            if (string.IsNullOrEmpty(answerText))
                return false;
            if (answerText.Length < 7 ^ studentNumber == 0 ^ subjectNumber == 0)
                return false;
            else
                return iStudent.AddNewAnswer(answerText, studentNumber, subjectNumber);
        }

        [HttpGet]
        [Route("navbar")]
        public string NavbarInfo()
        {
            var studentInfo = GetStudentInfo();
            string fullName = studentInfo.name + " " + studentInfo.sename;
            RepGroup groupRep = new RepGroup(db);
            var group = groupRep.GetGroup(studentInfo);
            //Данные студента
            string groupName;
            if (group != null)
                groupName = group.name;
            else
                groupName = "Не состоите в группе";

            dynamic NavbarJson = new JObject();
            NavbarJson.StudentName = fullName;
            NavbarJson.GroupName = groupName;

            //Пары сегодня
            if(group != null)
            {
                RepCourse courseRep = new RepCourse(db);
                var student = iStudent.GetStudent(studentInfo.id);
                var courses = courseRep.GetAllCourses(studentInfo.group);
                var subjects = courseRep.GetSubjectsToday(student);

                if (subjects != null && subjects.Count > 0)
                {
                    NavbarJson.SubjectsToday = new JArray() as dynamic;
                    foreach (var _subject in subjects)
                    {
                        dynamic subject = new JObject();
                        subject.Time = _subject.time.ToString();
                        subject.Name = courseRep.GetCourseBySubject(_subject).name;
                        NavbarJson.SubjectsToday.Add(subject);
                    }
                    NavbarJson.IsHasSubjectsToday = true;
                }
                else
                {
                    NavbarJson.IsHasSubjectsToday = false;
                }

                //Расписание на сегодня
                NavbarJson.Schelude = new JArray() as dynamic;
                bool IsNowNumerator = group.IsNowNumerator;
                bool IsHasSchedule = group.numeratorSchedule != null && group.denominatorSchedule != null;
                NavbarJson.IsHasSchedule = IsHasSchedule;
                if (IsHasSchedule)
                {
                    SchoolDay schoolDay;

                    if (IsNowNumerator) //TODO
                        schoolDay = group.numeratorSchedule.days[0];
                    else
                        schoolDay = group.denominatorSchedule.days[0];

                    dynamic Subject1 = new JObject();
                    dynamic Subject2 = new JObject();
                    dynamic Subject3 = new JObject();
                    Subject1.Name = schoolDay.firstCourseName;
                    Subject1.Time = schoolDay.firstTime;
                    Subject2.Name = schoolDay.secondCourseName;
                    Subject2.Time = schoolDay.secondTime;
                    Subject3.Name = schoolDay.thirdCourseName;
                    Subject3.Time = schoolDay.thirdTime;
                    NavbarJson.Schelude.Add(Subject1);
                    NavbarJson.Schelude.Add(Subject2);
                    NavbarJson.Schelude.Add(Subject3);
                }
            }

            //Уведомления
            var notifications = db.notifications.Where
                (x => x.personalNumber.ToString().Equals(studentInfo.numberOfAccount));
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
        private Student GetStudentInfo()
        {
            var student = iStudent.GetMinimalStudentInfo(userManager.GetUserAsync(User).
                GetAwaiter().GetResult().Id.ToString());

            return student;
        }
    }
}