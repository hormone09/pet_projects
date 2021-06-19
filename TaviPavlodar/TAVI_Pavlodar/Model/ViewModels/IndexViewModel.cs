using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TAVI_Pavlodar.Model.ViewModels
{
    public class IndexViewModel
    {
        public List<ProductType> AllTypes = new List<ProductType>();

        public List<Product> FavoriteProducts = new List<Product>();

        public string[] ImgPaths;
    }
}
