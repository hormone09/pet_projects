using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TAVI_Pavlodar.Model;

namespace TAVI_Pavlodar.Interfaces
{
    public interface IContent
    {
        public List<Product> GetProducts();
        public List<ProductType> GetTypes();
        public void EditUserData(User model);
        public Company GetCompanyData();
        public List<Product> FindProductsByType(int id);

    }
}
