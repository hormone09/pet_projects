using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TAVI_Pavlodar.Model.ViewModels
{
    public class OrderViewModel
    {
        public List<BasketItem> OrderItems = new List<BasketItem>();

        public double OrderPrice { get; set; }

        public string OrderUserName { get; set; }
        
        public DateTime OrderTime { get; set; }

        public DateTime DateForLoading { get; set; }

        public DateTime TimeForLoading { get; set; }

        public string UserId { get; set; }
    }
}
