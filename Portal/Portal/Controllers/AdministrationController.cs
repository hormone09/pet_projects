using Microsoft.AspNetCore.Mvc; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portal.Models;
using Portal.Models.ViewModels;
using Portal.Data;
using Portal.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Portal.Controllers
{
    [Authorize(Roles ="administration")]
    public class AdministrationController : Controller
    {
        private readonly AplicationDbContext db;
        private readonly IUpdate iUpdate;
        private readonly ITeacher iTeacher;
        public AdministrationController(AplicationDbContext db, IUpdate iUpdate, ITeacher iTeacher)
        {
            this.iUpdate = iUpdate;
            this.iTeacher = iTeacher;
            this.db = db;
        }
        public ViewResult MainPanel()
        {
            return View();
        }
        [HttpGet]
        public ViewResult AddPerson()
        {
            NewPersonViewModel model = new NewPersonViewModel();

            return View(model);
        }
        [HttpPost]
        public IActionResult AddPerson(NewPersonViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                bool EmailIsUsing = db.Users.SingleOrDefault(x => x.Email.Equals(model.email)) != null;
                if (!EmailIsUsing)
                {
                    RegistrationApplication newApplication = new RegistrationApplication(model);
                    bool result = iUpdate.SendApplication(model.name, newApplication.id, newApplication.email);
                    if (result)
                    {
                        db.registrationApplications.Add(newApplication);
                        db.SaveChanges();
                        return RedirectToAction("AddPerson");
                    }
                    else
                    {
                        return View(model);
                    }
                }
                else 
                    return View(model);
            }
        }

        [HttpPost]
        [Route("addGroup")]
        public string AddGroup(string gName, string tName, string tSename)
        {
            if(String.IsNullOrEmpty(gName) || String.IsNullOrEmpty(tName) 
                || String.IsNullOrEmpty(tSename))
            {
                return "Заполните поля правильно!";
            }

            var teacher = db.teachers.FirstOrDefault(x => x.name == tName && x.sename == tSename);
            if (teacher == null || teacher.IsHasGroup == true)
                return "Преподавателя с таким именем нет, или он уже является куратором!";
            else if (teacher.IsHasGroup == true)
                return "Преподаватель уже назначен куратором!";
            else
            {
                Group group = new Group
                {
                    name = gName,
                    curator = teacher
                };
                db.groups.Add(group);
                teacher.IsHasGroup = true;
                iTeacher.AddNotification("Вы назначены куратором", $"Группа: {group.name}",
                    teacher.numberOfAccount);


                return "Группа добавлена!";
            }
        }

        [HttpPost]
        [Route("addCourse")]
        public string AddCourse(string courseName, string groupName, 
            string teacherName, int numbersBorders)
        {
            if (String.IsNullOrEmpty(courseName) || String.IsNullOrEmpty(groupName)
                   || String.IsNullOrEmpty(teacherName) || numbersBorders <=0 )
            {
                return "Заполните все поля!";
            }
            var group = db.groups.SingleOrDefault(x => x.name.Equals(groupName));
            var teacher = db.teachers.SingleOrDefault(x => (x.name + " " + x.sename).Equals(teacherName));
            if (group == null)
                return "Такой группы не существует!";
            else if (teacher == null)
                return "Имя преподавателя указанно неверно!";
            else
            {
                Course course = new Course
                {
                    name = courseName,
                    group = group,
                    numberOfBorders = numbersBorders,
                    teacher = teacher,
                    borders = null,
                    marks = null
                };

                db.courses.Add(course);

                iTeacher.AddNotificationToGroup("Новый курс:", course.name, group.id);

                return $"Курс {courseName} добавлен в группу {groupName}!";
            }
        }

        [HttpPost]
        [Route("addStudentToGroup")]
        public string AddStudentToGroup(string email, string groupName)
        {
            if (String.IsNullOrEmpty(email) || String.IsNullOrEmpty(groupName))
            {
                return "Заполните все поля!";
            }

            var user = db.Users.SingleOrDefault(x => x.Email.Equals(email));
            if (user == null)
                return "Почтовый адресс указан неверно!";
            else
            {
                var student = db.students.SingleOrDefault
                    (x => x.numberOfAccount.Equals(user.Id.ToString()));
                var group = db.groups.SingleOrDefault(x => x.name.Equals(groupName));
                if (student.IsHasGroup == true)
                    return "Студент уже состоит в группе!";
                else if (group == null)
                    return "Название группы указанно неверно!";
                else
                {
                    student.group = group;
                    student.IsHasGroup = true;

                    var personalNumber = user.Id.ToString();
                    var head = "Добавление";
                    var message = $"Группа: {group.name}";
                    iTeacher.AddNotification(head, message, personalNumber);

                    return $"Студент {student.name}  {student.sename} " +
                        $"успешно добавлен в группу {group.name}";
                }
            }
        }
    }
}
