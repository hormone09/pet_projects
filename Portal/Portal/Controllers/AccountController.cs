using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portal.Models.ViewModels;
using Portal.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Portal.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Portal.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IUpdate iUpdate;
        private readonly AplicationDbContext db;
        private readonly IWebHostEnvironment appEnvironment;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, 
            AplicationDbContext db, IUpdate iUpdate, IWebHostEnvironment appEnvironment)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.iUpdate = iUpdate;
            this.db = db;
            this.appEnvironment = appEnvironment;
        }

        [Authorize]
        public RedirectToActionResult RedirectOnController()
        {
            string controller;
            var user = userManager.GetUserAsync(User).GetAwaiter().GetResult();
            var IsAdmin = userManager.IsInRoleAsync(user, "administration").GetAwaiter().GetResult();

            if (IsAdmin)
                return RedirectToAction("MainPanel", "Administration");
            else if (user.IsTeacher)
                controller = "Teacher";
            else
                controller = "Student";

            return RedirectToAction("PersonalArea", controller);
        }

        [HttpGet]
        public ViewResult Login()
        {
            LoginViewModel model = new LoginViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        { 

            bool IsUserNull = false;

            if (String.IsNullOrEmpty(model.login) || String.IsNullOrEmpty(model.login))
            {
                model.validatorForPassword = "Заполните все поля!";
                return View(model);
            }

            var user = await userManager.FindByNameAsync(model.login);
            IsUserNull = (user == null);

            if(IsUserNull)
            {
                model.validatorForLogin = "Пользователя с таким логином нет!";
                return View(model);
            }
            else
            {
                var result = await signInManager.PasswordSignInAsync(user, model.password, false, false);
                if(!result.Succeeded)
                {
                    model.validatorForPassword = "Пароль введен неверно!";
                    return View(model);
                }
            }

            return RedirectToAction("RedirectOnController", "Account");
        }
        [HttpGet]
        public IActionResult Register(string registerNumber)
        {
            var model = iUpdate.IsCanRegister(registerNumber);
            bool IsHasRegsiterPage = model != null;
            if(IsHasRegsiterPage)
            {
                return View(model);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            bool IsValid = !String.IsNullOrEmpty(model.login) && !String.IsNullOrEmpty(model.password)
                && !String.IsNullOrEmpty(model.password2);
            if (!IsValid)
            {
                return Redirect($"/Account/Register/?registerNumber={model.personalUrl}");
            }
            else
            {
                bool IsCanUseLogin = (userManager.FindByNameAsync(model.login).GetAwaiter().GetResult() 
                    == null);
                bool IsPasswordMatch = model.password.Equals(model.password2);
                if (IsCanUseLogin && IsPasswordMatch)
                {
                    User newUser = new User
                    {
                        UserName = model.login,
                        NormalizedUserName = $"{model.name}_{model.sename}",
                        Email = model.email,
                        IsTeacher = model.IsTeacher,
                    };
                    await userManager.CreateAsync(newUser, model.password);

                    if (model.IsTeacher)
                    {
                        await userManager.AddToRoleAsync(newUser, "teacher");
                        Teacher newTeacher = new Teacher(model, newUser.Id.ToString());

                        db.teachers.Add(newTeacher);
                    }
                    else
                    {
                        await userManager.AddToRoleAsync(newUser, "student");

                        Student student = new Student(model, newUser.Id.ToString());
                        db.students.Add(student);
                    }

                    db.registrationApplications.Remove(
                        db.registrationApplications.Single(x => x.id.Equals(model.personalUrl)));
                    db.SaveChanges();
                    return RedirectToAction("Login", "Account");
                }
                else
                    return Redirect($"/Account/Register/?registerNumber={model.personalUrl}");
            }
        }
        public async Task<RedirectToActionResult> LogOff()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Login", "Account");
        }

        [Authorize]
        [HttpPost]
        public async Task<RedirectToActionResult> UploadImage(IFormFile userImage)
        {
            if (userImage != null)
            {
                string path = "/photos/" + userImage.FileName;
                using (var fileStream = new FileStream(appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await userImage.CopyToAsync(fileStream);
                }
                var userNumber = userManager.GetUserAsync(User).GetAwaiter().GetResult().Id;
                UserImage newImage = new UserImage
                {
                    name = userImage.FileName,
                    fullPuth = appEnvironment.WebRootPath + path,
                    userId = userNumber
                };

                DeleteIfHasPhoto(userNumber);
                db.userImages.Add(newImage);
                db.SaveChanges();
            }

            return RedirectToAction("RedirectOnController");
        }

        private void DeleteIfHasPhoto(Guid userId)
        {
            var photo = db.userImages.SingleOrDefault(x => x.userId.Equals(userId));
            if(photo != null)
            {
                System.IO.File.Delete(photo.fullPuth);
                db.userImages.Remove(photo);
            }
        }

        [HttpGet]
        [Route("DeleteNotifications")]
        public async Task DeleteAllNotifications()
        {
            var user = await userManager.GetUserAsync(User);
            var id = user.Id;
            using (db)
            {
                var notifications = db.notifications.Where(x => x.personalNumber.Equals(id));
                db.notifications.RemoveRange(notifications);
                db.SaveChanges();
            }
        }
    }
}
