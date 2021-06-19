using System;
using System.Collections.Generic;
using TAVI_Pavlodar.Model.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace TAVI_Pavlodar.Model
{
    public class Loading
    {
        public string Id { get; set; }
        public string FullnameOfUser { get; set; }
        public string UserId { get; set; }
        public List<ProductOnLoading> Products { get; set; }
        public DateTime DayForLoading { get; set; }
        public DateTime TimeForLoading { get; set; }
        public int MinutesForLoading { get; set; }
        public Loading(OrderViewModel model)
        {
            FullnameOfUser = model.OrderUserName;
            UserId = model.UserId;
            DayForLoading = model.DateForLoading;
            TimeForLoading = model.TimeForLoading;
            Id = Guid.NewGuid().ToString();
        }

        public Loading() { }
    }

}
