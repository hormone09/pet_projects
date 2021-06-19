using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Provider.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Provider.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        public HomeController(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }

        public ActionResult Index()
        {
            var path = webHostEnvironment.WebRootPath + "/Index.html";
            StreamReader reader = new StreamReader(path);
            var fileBytes = System.IO.File.ReadAllBytes(path);
            FileContentResult file = File(fileBytes, "text/html");

            return file;
        }
        public ActionResult PersonalArea()
        {
            var path = webHostEnvironment.WebRootPath + "/PersonalArea.html";
            StreamReader reader = new StreamReader(path);
            var fileBytes = System.IO.File.ReadAllBytes(path);
            FileContentResult file = File(fileBytes, "text/html");

            return file;
        }
        public ActionResult Rates()
        {
            var path = webHostEnvironment.WebRootPath + "/Rates.html";
            StreamReader reader = new StreamReader(path);
            var fileBytes = System.IO.File.ReadAllBytes(path);
            FileContentResult file = File(fileBytes, "text/html");

            return file;
        }
        public ActionResult Services()
        {
            var path = webHostEnvironment.WebRootPath + "/Services.html";
            StreamReader reader = new StreamReader(path);
            var fileBytes = System.IO.File.ReadAllBytes(path);
            FileContentResult file = File(fileBytes, "text/html");

            return file;
        }
        public ActionResult Help()
        {
            var path = webHostEnvironment.WebRootPath + "/Help.html";
            StreamReader reader = new StreamReader(path);
            var fileBytes = System.IO.File.ReadAllBytes(path);
            FileContentResult file = File(fileBytes, "text/html");

            return file;
        }
        public ActionResult NewAbonent()
        {
            var path = webHostEnvironment.WebRootPath + "/NewUser.html";
            StreamReader reader = new StreamReader(path);
            var fileBytes = System.IO.File.ReadAllBytes(path);
            FileContentResult file = File(fileBytes, "text/html");

            return file;
        }
        public ActionResult Sign()
        {
            var path = webHostEnvironment.WebRootPath + "/Login.html";
            StreamReader reader = new StreamReader(path);
            var fileBytes = System.IO.File.ReadAllBytes(path);
            FileContentResult file = File(fileBytes, "text/html");

            return file;
        }
        [Authorize(Roles = "admin")]
        public ActionResult ManagerMenu()
        {
            var path = webHostEnvironment.WebRootPath + "/ManagerMain.html";
            StreamReader reader = new StreamReader(path);
            var fileBytes = System.IO.File.ReadAllBytes(path);
            FileContentResult file = File(fileBytes, "text/html");

            return file;
        }
        [Authorize(Roles = "admin")]
        public ActionResult Applications()
        {
            var path = webHostEnvironment.WebRootPath + "/Applications.html";
            StreamReader reader = new StreamReader(path);
            var fileBytes = System.IO.File.ReadAllBytes(path);
            FileContentResult file = File(fileBytes, "text/html");

            return file;
        }

    }
}

