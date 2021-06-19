using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TAVI_Pavlodar.Data;
using TAVI_Pavlodar.Model;
using TAVI_Pavlodar.Interfaces;
using TAVI_Pavlodar.Model.ViewModels;

namespace TAVI_Pavlodar
{
    public class PurchaesRep : IPurchaes
    {
        public string[] TypesOfStatus = new string[4] { "Отказано", "В обработке", "Потвержден", "Выполнен" };

        private readonly AplicationDbContext db;

        public PurchaesRep(AplicationDbContext db)
        {
            this.db = db;
        }

        public void AddPurchaes(OrderViewModel model, string id)
        {
            Purchase purchase = new Purchase
            {
                nameOfClient = model.OrderUserName,
                timeOfPurchaes = model.OrderTime,
                finalyPrice = model.OrderPrice,
                userId = id,
                purchaesElements = new List<PurchaesElement>(),
                Status = TypesOfStatus[1]
            };

            foreach (BasketItem el in model.OrderItems)
            {
                PurchaesElement NewPurchaesElement = new PurchaesElement
                {
                    name = el.desk,
                    amount = el.amount,
                    price = el.price,
                    PurchaesNumber = purchase.id
                };
                purchase.purchaesElements.Add(NewPurchaesElement);
                db.PurchaesElements.Add(NewPurchaesElement);
                db.SaveChanges();
            }

            db.Purchases.Add(purchase);
            db.SaveChanges();
        }

        public void ChangePurchaesStatus(Purchase purchase, bool IsApproved)
        {
            if (IsApproved)
            {
                if (purchase.Status != TypesOfStatus[3])
                {
                    for (int i = 0; i < TypesOfStatus.Length; i++)
                    {
                        if (purchase.Status.Equals(TypesOfStatus[i]))
                        {
                            purchase.Status = TypesOfStatus[i + 1];
                            break;
                        }
                    }
                }
            }
            else
            {
                purchase.Status = TypesOfStatus[0];
            }
            db.SaveChanges();
        }

        public List<Purchase> GetPurchases()
        {
            //var currentPurchases = db.purchases.Where(x => x.Status.Equals(TypesOfStatus[1])).ToList();
            var currentPurchases = db.Purchases.ToList();
            return currentPurchases;
        }

        public List<Purchase> GetActiveOrders(string id)
        {
            var userOrders = db.Purchases.Where(x => x.userId.Equals(id));
            var activeOrders = userOrders.Where(x => x.Status.Equals("В обработке") | x.Status.Equals("Потвержден")).ToList();
            List<Purchase> result = new List<Purchase>();
            result = activeOrders;
            for (int i = 0; i < activeOrders.Count; i++)
            {
                result[i].purchaesElements = new List<PurchaesElement>();
                result[i].purchaesElements.AddRange(activeOrders[i].purchaesElements);
            }

            return result;
        }

        public List<Purchase> GetPassiveOrders(string id)
        {
            var userOrders = db.Purchases.Where(x => x.userId.Equals(id));
            var passiveOrders = userOrders.Where(x => x.Status.Equals("Отклонен") | x.Status.Equals("Выполнен")).ToList();

            return passiveOrders;

        }

        public List<Loading> SortLoadingsByTime(List<Loading> comeIn)
        {
            Loading onlyInRange = new Loading();
            int count = comeIn.Count()-1;
            bool IsNotDone = true, IsNeed;

            while(true) //ByHour
            {
                for (int i = 0; i < count; i++)
                {
                    IsNeed = comeIn[i].TimeForLoading.Hour > comeIn[i + 1].TimeForLoading.Hour;
                    if(IsNeed)
                    {
                        onlyInRange = comeIn[i];
                        comeIn[i] = comeIn[i + 1];
                        comeIn[i + 1] = onlyInRange;
                    }
                }
                IsNotDone = false;
                for (int i=0; i< count; i++)
                {
                    if (comeIn[i].TimeForLoading.Hour > comeIn[i + 1].TimeForLoading.Hour)
                        IsNotDone = true;
                }
                if (!IsNotDone) break;
            }

            while (true) //ByMinute
            {
                for (int i = 0; i < count; i++)
                {
                    IsNeed = (comeIn[i].TimeForLoading.Hour == comeIn[i + 1].TimeForLoading.Hour)
                        && (comeIn[i].TimeForLoading.Minute > comeIn[i + 1].TimeForLoading.Minute);
                    if (IsNeed)
                    {
                        onlyInRange = comeIn[i];
                        comeIn[i] = comeIn[i + 1];
                        comeIn[i + 1] = onlyInRange;
                    }
                }
                IsNotDone = false;
                for (int i = 0; i < count; i++)
                {
                    if ((comeIn[i].TimeForLoading.Hour == comeIn[i + 1].TimeForLoading.Hour)
                        && (comeIn[i].TimeForLoading.Minute > comeIn[i + 1].TimeForLoading.Minute))
                        IsNotDone = true;
                }
                if (!IsNotDone) break;
            }

            return comeIn;
        }
        public int GetLoadingTime(List<ProductOnLoading> products)
        {
            int result = 0;

            foreach(var product in products)
            {
                int factor = 2;
                switch(product.typeName)
                {
                    case "Паралон": factor = 3;
                            break;
                    case "ЛДСП": factor = 5;
                            break;
                    case "Матрац": factor = 5;
                            break;
                }

                result += (int)product.amount * factor;
            }

            return result;
        }
        public void RemoveBasketItems(int id)
        {
            db.BasketItems.Remove(db.BasketItems.Single(x => x.id == id));
            db.SaveChanges();
        }
    }
}
