using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TAVI_Pavlodar.Model;

namespace TAVI_Pavlodar.Interfaces
{
    public interface ISearch
    {
        public string GetSinonim(string query);

        public List<Product> GetProducts(string query);

        public ProductType GetProductType(string query);
    }
}
