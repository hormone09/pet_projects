using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TAVI_Pavlodar.Model.ViewModels
{
    public class SearchViewModel
    {
        public List<Product> products = new List<Product>();

        public ProductType type = new ProductType();

        public string search { get; set; }
    }
}
