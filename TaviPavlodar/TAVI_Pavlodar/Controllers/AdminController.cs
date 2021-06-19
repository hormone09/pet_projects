using Microsoft.AspNetCore.Mvc;
using TAVI_Pavlodar.Model.ViewModels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using TAVI_Pavlodar.Model;
using Microsoft.AspNetCore.Identity;

namespace TAVI_Pavlodar.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AdminController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await userManager.FindByNameAsync(model.Login);
            if(user == null )
            {
                ModelState.AddModelError("Login", "User not found");
                model.ErrorMassage = "Пользователя с таким логином нет";
                return View();
            }
            var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);
            if(!result.Succeeded)
            {
                return View(model);
            }

            return Redirect("/Home/Index");
            
        }

        public async Task<IActionResult> LogOff()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
