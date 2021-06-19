using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TAVI_Pavlodar.Model.ViewModels
{
    public class CheckOrdersManagerViewModel
    {
        public string[] TypesOfStatus;

        public List<Purchase> status0 = new List<Purchase>();

        public List<Purchase> status1 = new List<Purchase>();

        public List<Purchase> status2 = new List<Purchase>();

        public List<Purchase> status3 = new List<Purchase>();
    }
}
