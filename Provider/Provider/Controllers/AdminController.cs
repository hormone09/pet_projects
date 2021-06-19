using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Provider.Interfaces;
using Provider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Provider.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly IUpdate update;

        public AdminController(IUpdate update)
        {
            this.update = update;
        }

        [HttpPost]
        [Route("Content/AddRate")]
        public string AddRate(Rate rate)
        {
            return update.AddRate(rate);
        }

        [HttpPost]
        [Route("Content/AddService")]
        public string AddService(Service service)
        {
            return update.AddService(service);
        }

        [HttpGet]
        [Route("Content/Delete")]
        public string Delete(int objectId, string objectType)
        {
            string result = "Error!";
            if (objectId == 0  || string.IsNullOrEmpty(objectType))
                return result;
            else
                return update.Delete(objectId, objectType);
        }

        [HttpGet]
        [Route("Content/GetApplications")]
        public string GetApplications()
        {
            return update.GetAllApplications();
        }

        [HttpGet]
        [Route("Content/ConfirmConnectApplicate")]
        public bool ConfirmApplicate(int applicateId)
        {
            return update.ConfirmApplicate(applicateId);
        }
        [HttpGet]
        [Route("Content/DeleteApplicate")]
        public bool Delete(int applicateId, bool IsConnectApp)
        {
            return update.DeleteApp(applicateId, IsConnectApp);
        }

    }
}
