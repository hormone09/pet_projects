using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Provider.Interfaces;
using Provider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Provider.Controllers
{
    public class ContentController : Controller
    {
        private readonly IServices services;
        private readonly UserManager<User> userManager;

        public ContentController(IServices services, UserManager<User> userManager)
        {
            this.services = services;
            this.userManager = userManager;
        }

        [HttpGet]
        [Route("Content/GetRates")]
        public string GetRates(bool IsForInternet)
        {
            string result;

            if (IsForInternet)
                result = services.GetInternetRates();
            else
                result = services.GetTelephoneRates();

            if (result != null)
                return result;
            else
                return "Error";
        }

        [HttpGet]
        [Route("Content/GetServices")]
        public string GetServices(string serviceType)
        {
            if (string.IsNullOrEmpty(serviceType))
                return "Error!";
            else if (!serviceType.Equals(ServiceTypes.Balance.ToString())
                && !serviceType.Equals(ServiceTypes.Internet.ToString())
                && !serviceType.Equals(ServiceTypes.Phone.ToString())
                && !serviceType.Equals(ServiceTypes.NewUsers.ToString())
                && !serviceType.Equals("All"))
                return "Error!";
            else
                return services.GetServices(serviceType);
        }

        [Authorize]
        [HttpGet]
        [Route("Content/Applicate")]
        public bool NewApplicate(string mobileCode, string type)
        { 
            if (!string.IsNullOrEmpty(mobileCode) && !string.IsNullOrEmpty(type) &&
                (type.Equals(ApplicateTypes.RateConnection.ToString()) ||
                type.Equals(ApplicateTypes.ServiceConnection.ToString()) ||
                type.Equals(ApplicateTypes.RateDisconnect.ToString()) ||
                type.Equals(ApplicateTypes.ServiceDisconnect.ToString())))
            {
                var user = userManager.GetUserAsync(User).GetAwaiter().GetResult();
                Applicate applicate = new Applicate
                {
                    UserName = user.UserName,
                    ApplicateType = type,
                    NewServiceName = mobileCode,
                };
                return services.NewApplicate(applicate);
            }
            else
                return false;
        }

        [HttpPost]
        [Route("Content/NewUserApplicate")]
        public RedirectToActionResult ApplicateForNewUser(NewUserApplicate applicate)
        {
            if (!string.IsNullOrEmpty(applicate.Name) || !string.IsNullOrEmpty(applicate.Sename)
                || !string.IsNullOrEmpty(applicate.PersonalNumber) || !string.IsNullOrEmpty(applicate.Phone))
            {
                services.NewUserApplicate(applicate);
                return RedirectToAction("Index", "Home");
            }
            else
                return RedirectToAction("NewUser", "Home");
        }

        [Authorize]
        [HttpGet]
        [Route("Content/GetUserData")]
        public string GetUserData()
        {
            var userId = userManager.GetUserAsync(User).GetAwaiter().GetResult().Id;
            return services.GetUserData(userId);
        }
    }
}
