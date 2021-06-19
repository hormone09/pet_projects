using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TAVI_Pavlodar.Data;
using TAVI_Pavlodar.Model;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TAVI_Pavlodar.Interfaces;
using TAVI_Pavlodar.Model.ViewModels;
using System;

namespace TAVI_Pavlodar.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly AplicationDbContext db;
        private readonly UserManager<User> userManager;
        private readonly IPurchaes IPurchaes;
        private readonly ISearch ISearch;
        private readonly IContent IContent;

        public HomeController(AplicationDbContext db, UserManager<User> userManager,IPurchaes IPurchaes, 
            ISearch ISearch, IContent IContent)
        {
            this.db = db;
            this.userManager = userManager;
            this.IPurchaes = IPurchaes;
            this.ISearch = ISearch;
            this.IContent = IContent;
        }

        [HttpGet]
        public IActionResult Index(string result = "")
        {
            IndexViewModel model = new IndexViewModel();
            ProductType currentType;
            int num = 0;
            var products = IContent.GetProducts();
            var types = IContent.GetTypes();
            var FavoriteProducts = GetUser().FavoriteProducts;
                FavoriteProducts = new List<Product>();
                while(FavoriteProducts.Count < 5)
                {
                    foreach (var product in products)
                    {
                        FavoriteProducts.Add(product);
                        num++;
                    }
                }

            model.FavoriteProducts = FavoriteProducts;

            model.AllTypes = db.Types.ToList();
            model.ImgPaths = new string[FavoriteProducts.Count];
            for (int i = 0; i < FavoriteProducts.Count; i++)
            {
                currentType = types.Single(x => x.id == FavoriteProducts[i].typeId);
                model.ImgPaths[i] = currentType.ImgPath;
            }

            return View(model);
        }

        [HttpGet] 
        public ViewResult Company()
        {
            var model = IContent.GetCompanyData();
            return View(model);
        }

        [HttpGet]
        public ViewResult ShowUserInfo(bool edit = false)
        {
            var model = GetUser();
            ViewBag.Edit = edit;
            return View(model);
        }

        public RedirectToActionResult EditUserInfo(User model)
        {
            IContent.EditUserData(model);

            return RedirectToAction("ShowUserInfo");
        }

        [HttpGet]
        public IActionResult CurrentType(int id)
        {
            CurrentTypeViewModel model = new CurrentTypeViewModel();

            var currentProducts = IContent.FindProductsByType(id);

            model.products = currentProducts;
            model.Count = currentProducts.Count / 2;
            model.Num = 0;

            return View(model);
        }

        public IActionResult ShowActiveUserOrders()
        {
            var ordersOfUser = GetUser().Id;
            var orders = IPurchaes.GetActiveOrders(ordersOfUser.ToString());

            return View("ShowOrders", orders);
        }

        public IActionResult ShowFinishedOrders()
        {
            var ordersOfUser = GetUser().Id;
            var orders = IPurchaes.GetPassiveOrders(ordersOfUser.ToString());

            return View("ShowOrders", orders);
        }

        [HttpGet]
        public IActionResult Basket()
        {
            return View(GetUserBasket());
        }

        [HttpPost]
        public RedirectResult AddToBasket(int id, int amount = 0)
        {
            var product = IContent.GetProducts().Single(x => x.id == id);
            GetUserBasket().AddToBasket(product, amount);
            return Redirect($"/Home/CurrentType/?id={product.typeId}");
        }

        [HttpPost]
        public RedirectResult RemoveFromBasket(int id)
        {
            var itemForRemove = db.BasketItems.Single(x => x.id == id);
            GetUserBasket().DeleteFromBasket(itemForRemove);
            return Redirect("/Home/Basket");
        }

        [HttpGet]
        public IActionResult Order()
        {
            OrderViewModel model = new OrderViewModel
            {
                UserId = GetUser().Id.ToString(),
                OrderPrice = GetUserBasket().finalPrice,
                OrderUserName = $"{GetUser().FirstName} {GetUser().LastName}",
                OrderTime = DateTime.Now
            };

            model.OrderItems = new List<BasketItem>();
            model.OrderItems.AddRange(GetUserBasket().items);

            foreach (BasketItem el in model.OrderItems)
            {
                el.price *= el.amount;
            }

            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult OrderPerfect(OrderViewModel model)
        {
            IPurchaes.AddPurchaes(model, GetUser().Id.ToString());

            Loading NewLoading = new Loading(model);
            using (db)
            {
                var basket = GetUserBasket().items;
                foreach (var basketItem in basket)
                    db.ProductsForLoading.Add(new ProductOnLoading
                    { 
                        typeName = basketItem.type,
                        loading = NewLoading,
                        amount = basketItem.amount,
                        desk = basketItem.desk,
                    });
                NewLoading.MinutesForLoading = IPurchaes.GetLoadingTime(NewLoading.Products);
                db.Loadings.Add(NewLoading);
                GetUserBasket().ClearBasket();
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult PersonalArea()
        {
            Purchase box = new Purchase();
            PersonalAreaViewModel model = new PersonalAreaViewModel();
            model.FullUserName = $"{GetUser().FirstName} {GetUser().LastName}";
            model.Purchases = db.Purchases.Where(x => x.userId.Equals(GetUser().Id.ToString())).ToList();
            foreach (Purchase el in model.Purchases)
            {
                el.purchaesElements = new List<PurchaesElement>();
                el.purchaesElements.AddRange(db.PurchaesElements.Where(x => x.PurchaesNumber.Equals(el.id)).ToList());
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult ShowAllLoadings()
        {
            bool IsCurrentDay = false;
            int num = 0;
            List<Loading> model = new List<Loading>();
            string day = DateTime.Now.ToShortDateString();
            foreach (var el in db.Loadings)
            {
                IsCurrentDay = el.DayForLoading.ToShortDateString().Equals(day);
                if (IsCurrentDay)
                {
                    model.Add(el);
                    model[num].Products = db.ProductsForLoading.Where(x => x.loading == el).ToList();
                    model[num].Products.AddRange(el.Products);
                    num++;
                }
            }
            model = IPurchaes.SortLoadingsByTime(model);

            return View(model);
        }

        public Basket GetUserBasket()
        {
            Basket basket = new Basket();
            var user = userManager.GetUserAsync(User).GetAwaiter().GetResult();
            basket = db.Baskets.Single(x => x.UserId.Equals(user.Id.ToString()));
            basket.items = new List<BasketItem>();
            basket.items = db.BasketItems.Where(c => c.BasketId == basket.id).ToList();

            return basket;
        }

        [HttpGet]
        public ActionResult Search(string query)
        {
            SearchViewModel model = new SearchViewModel();
            model.search = query;
            string queryCompleted = ISearch.GetSinonim(query);
            model.products = ISearch.GetProducts(queryCompleted);
            //model.type = ISearch.GetProductType(queryCompleted);
            return View(model);
        }

        public User GetUser()
        {
            User currentUser = new User();
            currentUser = userManager.GetUserAsync(User).GetAwaiter().GetResult();

            return currentUser;
        }
    }
}
