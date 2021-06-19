using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Provider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Provider.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager,
            RoleManager<Role> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpPost]
        [Route("Account/SignIn")]
        public async Task<string> Login(string login, string password)
        {
            dynamic result = new JObject();
            result.IsAuthorize = false;
            result.InfoMessage = "";

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
                result.InfoMessage = "Заполните все поля!";
            else
            {
                bool IsCurrentLogin = await userManager.FindByNameAsync(login) != null;
                if (IsCurrentLogin)
                {
                    var PasswordCorrect = await signInManager.PasswordSignInAsync(login, password, false, false);

                    if (PasswordCorrect.Succeeded)
                        result.IsAuthorize = true;
                    else
                        result.InfoMessage = "Пароль указан неверно!";
                }
                else
                    result.InfoMessage = "Пользователя с таким логином нет!";
            }

            var json = JsonConvert.SerializeObject(result);
            return json;
        }

        [HttpPost]
        [Route("Account/SignUp")]
        public async Task<string> Register(User user, string password, string password2)
        {
            dynamic result = new JObject();
            result.IsAuthorize = false;
            result.InfoMessage = "";

            if (string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(password)
                || string.IsNullOrEmpty(password2) || string.IsNullOrEmpty(user.UserName))
                result.InfoMessage = "Поля заполнены неверно!";
            else if (password.Length < 6 || user.UserName.Length < 7)
                result.InfoMessage = "Логин и пароль заданы неверно!";
            else if (!password.Equals(password2))
                result.InfoMessage = "Пароли не соавпадают!";
            else
            {
                bool IsNameUsing = await userManager.FindByNameAsync(user.UserName) != null;
                if (IsNameUsing)
                    result.InfoMessage = "Пользователь с таким логином уже есть!";
                else
                {
                    user.FullName = user.Name + "   " + user.Sename;
                    await userManager.CreateAsync(user, password);
                    await userManager.AddToRoleAsync(user, "user");
                    await signInManager.PasswordSignInAsync(user.UserName, password, false, false);

                    result.IsAuthorize = true;
                    result.InfoMessage = "Вы успешно зарегестрированны!";
                }
            }

            var json = JsonConvert.SerializeObject(result);
            return json;
        }

        [Authorize]
        [HttpPost]
        [Route("Account/LogOff")]
        public async Task LogOff()
        {
            await signInManager.SignOutAsync();
        }

        [HttpGet]
        [Route("Account/AuthorizeResult")]
        public bool UserIsAuthorize()
        {
            return User.Identity.IsAuthenticated;
        }

        [HttpGet]
        [Route("Account/IsAdmin")]
        public bool UserIsAdmin()
        {
            return User.IsInRole("admin");
        }
    }
}
