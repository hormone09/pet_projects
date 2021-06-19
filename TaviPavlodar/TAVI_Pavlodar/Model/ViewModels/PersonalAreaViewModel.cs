using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TAVI_Pavlodar.Model.ViewModels
{
    public class PersonalAreaViewModel
    {
        public List<Purchase> Purchases = new List<Purchase>();
        
        public string FullUserName { get; set; }

        //public List<Purchase> LoadingToday { get; set; }
    }
}
