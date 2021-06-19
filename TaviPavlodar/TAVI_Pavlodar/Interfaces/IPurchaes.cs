using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TAVI_Pavlodar.Model;
using TAVI_Pavlodar.Model.ViewModels;

namespace TAVI_Pavlodar.Interfaces
{
    public interface IPurchaes
    {
        public void AddPurchaes(OrderViewModel model, string id);
        public void ChangePurchaesStatus(Purchase purchase, bool IsApproved);
        public List<Purchase> GetPurchases();
        public List<Purchase> GetActiveOrders(string id);
        public List<Purchase> GetPassiveOrders(string id);
        public List<Loading> SortLoadingsByTime(List<Loading> comeIn);
        public int GetLoadingTime(List<ProductOnLoading> products);
        public void RemoveBasketItems(int id);
    }
}
