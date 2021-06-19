using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using TAVI_Pavlodar.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace TAVI_Pavlodar.Model
{
    public class Basket
    {
        private readonly AplicationDbContext db;

        public Basket(AplicationDbContext db)
        {
            this.db = db;
        }

        //^^^^^^^^DATABASE^^^^^^^^

        public string id { get; set; }

        public double finalPrice { get; set; }

        public List<BasketItem> items { get; set; }

        public string UserId { get; set; }

        public Basket(string userId)
        {
            id = Guid.NewGuid().ToString();
            finalPrice = 0;
            UserId = userId;
        }

        public Basket() { }

        public void AddToBasket(Product product, int amount)
        {
            var currentProduct = IsProductInBasket(product);
            bool IsHave = currentProduct != null;
            if(IsHave)
            {
                currentProduct.amount += amount;
                finalPrice += product.price * amount;
            }
            else
            {
                BasketItem basketItem = new BasketItem
                {
                    price = product.price,
                    desk = $"Описание товара: {product.desk}, {product.parametr1}, {product.parametr2}",
                    type = product.desk,
                    amount = amount
                };
                items.Add(basketItem);
                finalPrice += product.price * amount;

            }
            

            db.SaveChanges();
        }

        public BasketItem IsProductInBasket(Product product)
        {
            bool IsHave = false;
            BasketItem result = null;
            foreach(var el in items)
            {
                IsHave = el.desk.Equals($"Описание товара: {product.desk}, {product.parametr1}, {product.parametr2}");
                if(IsHave)
                {
                    result = new BasketItem();
                    result = el;
                    break;
                }

            }

            return result;
        }
        public void DeleteFromBasket(BasketItem basketItem)
        {
            finalPrice -= basketItem.price * basketItem.amount;
            items.Remove(basketItem);
            db.SaveChanges();
        }

        public void ClearBasket()
        {
            items.Clear();
            finalPrice = 0;
            foreach(BasketItem item in db.BasketItems)
            {
                if (item.BasketId == null)
                    db.BasketItems.Remove(item);
            }

            db.SaveChanges();
        }

    }
}
