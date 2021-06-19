using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using TAVI_Pavlodar.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using TAVI_Pavlodar.Model.ViewModels;
using Microsoft.AspNetCore.Identity;
using TAVI_Pavlodar.Model;
using TAVI_Pavlodar.Interfaces;

namespace TAVI_Pavlodar.Controllers
{
    [Authorize(Roles = "Manager")]
    public class ManagerController : Controller
    {
        private readonly AplicationDbContext db;
        private readonly UserManager<User> userManager;
        private readonly IPurchaes purchaesRep;

        public ManagerController(AplicationDbContext db, UserManager<User> userManager, IPurchaes purchaesRep)
        {
            this.db = db;
            this.userManager = userManager;
            this.purchaesRep = purchaesRep;
        }

        [HttpGet]
        public ViewResult CreateNewUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<RedirectToActionResult> CreateNewUser(CreateViewModel model)
        {
            User newUser = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                UserName = model.Login
            };

            newUser.Login = newUser.UserName;
            await userManager.CreateAsync(newUser, model.Password);
            await userManager.AddToRoleAsync(newUser, "User");
            db.Baskets.Add(new Basket(newUser.Id.ToString()));
            db.SaveChanges();

            return RedirectToAction("CreateNewUser");
        }

        [HttpGet]
        public ViewResult DeleteUser()
        {
            //List<User> model = new List<User>();
            //var role = db.Roles.Single(x => x.Name.Equals("User"));
            //var userInRole = db.UserRoles.Where(x => x.RoleId.Equals(role.Id)).ToList();
            //foreach(var inRole in userInRole)
            //{
            //    foreach(var user in db.Users)
            //    {
            //        if (user.Id.ToString().Equals(inRole.UserId))
            //            model.Add(user);
            //    }
            //}

            var model = db.Users.ToList();

            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult DeleteUser(string id)
        {
            var user = db.Users.Single(x => x.Id.ToString().Equals(id));
            db.Users.Remove(user);
            db.SaveChanges();

            return RedirectToAction("DeleteUser");
        }

        [HttpGet]
        public ViewResult EditProduct(int number = -1)
        {
            EditViewModel model = new EditViewModel(db);
            if (number != -1)
            {
                model.currentProduct = new Product();
                model.currentProduct = db.Products.Single(x => x.id == number);
                ViewBag.EditProduct = true;
            }
            else
                ViewBag.EditProduct = false;
            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult EditProduct(ProductEdited model)
        {
            var currentProduct = db.Products.Single(x => x.id == model.id);

            currentProduct.type = model.type;
            currentProduct.desk = model.desk;
            currentProduct.parametr1 = model.parametr1;
            currentProduct.parametr2 = model.parametr2;
            currentProduct.price = model.price;
            currentProduct.avalib = model.avalib;
            db.SaveChanges();

            return RedirectToAction("EditProduct");
        }

        public ViewResult AddProduct()
        {
            var model = db.Types.ToList();

            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult AddProduct(AddProductViewModel model)
        {
            var currentType = db.Types.Single(x => x.id == model.typeId);
            Product newProduct = new Product
            {
                desk = model.desk,
                parametr1 = model.parametr1,
                parametr2 = model.parametr2,
                price = model.price,
                avalib = model.avalib,
                type = currentType.name,
                typeId = model.typeId,
            };
            db.Products.Add(newProduct);
            db.SaveChanges();

            return RedirectToAction("AddProduct");
        }

        [HttpPost]
        public RedirectResult DeleteProduct(int id)
        {
            var ProductForRemove = db.Products.Single(x => x.id == id);
            db.Products.Remove(ProductForRemove);
            db.SaveChanges();
            return Redirect("/Home/Index");
        }

        public ViewResult CheckOrders()
        {
            var allPurchases = purchaesRep.GetPurchases();
            allPurchases.OrderBy(x => x.timeOfPurchaes);

            CheckOrdersManagerViewModel model = new CheckOrdersManagerViewModel();
            model.TypesOfStatus = new string[4] { "Отказано", "В обработке", "Потвержден", "Выполнен" };
            model.status0.AddRange(allPurchases.Where(x => x.Status.Equals(model.TypesOfStatus[0])));
            model.status1.AddRange(allPurchases.Where(x => x.Status.Equals(model.TypesOfStatus[1])));
            model.status2.AddRange(allPurchases.Where(x => x.Status.Equals(model.TypesOfStatus[2])));
            model.status3.AddRange(allPurchases.Where(x => x.Status.Equals(model.TypesOfStatus[3])));

            return View(model);
        }

        [HttpGet]
        public ViewResult FindOrder()
        {
            ViewBag.IsNull = false;
            return View();
        }

        [HttpPost]
        public IActionResult FindOrder(int id)
        {
            Purchase model = new Purchase();
            model.purchaesElements = new List<PurchaesElement>();
            bool IsNull = false;
            try
            {
                var currentPurchaes = db.Purchases.Single(x => x.id == id);
                model.purchaesElements.AddRange(currentPurchaes.purchaesElements);
                model = currentPurchaes;
            }
            catch(Exception)
            {
                IsNull = true;
                model = null;
            }
            ViewBag.IsNull = IsNull;
            return View(model);
        }

        public RedirectToActionResult EditOrderStatus(int id, bool IsApproved = true)
        {
            purchaesRep.ChangePurchaesStatus(db.Purchases.Single(x => x.id == id), IsApproved);
            return RedirectToAction("CheckOrders");
        }
    }
}
