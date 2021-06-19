using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TAVI_Pavlodar.Model.ViewModels
{
    public class CurrentTypeViewModel
    {
        public List<Product> products = new List<Product>();

        public int Count { get; set; }

        public int Num { get; set; }
    }
}
