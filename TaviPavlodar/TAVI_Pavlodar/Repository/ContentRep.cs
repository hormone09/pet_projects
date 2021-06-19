using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TAVI_Pavlodar.Data;
using TAVI_Pavlodar.Interfaces;
using TAVI_Pavlodar.Model;

namespace TAVI_Pavlodar.Repository
{
    public class ContentRep : IContent
    {
        private readonly AplicationDbContext db;

        public ContentRep(AplicationDbContext db)
        {
            this.db = db;
        }
        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            products.AddRange(db.Products);
            return products;
        }

        public List<ProductType> GetTypes()
        {
            return db.Types.ToList();
        }
        public void EditUserData(User model)
        {
            using (db)
            {
                var user = db.Users.Single(x => x.Id.Equals(model.Id));

                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.PhoneNumber = model.PhoneNumber;
                user.Email = model.Email;
                db.SaveChanges();
            }
        }

        public Company GetCompanyData()
        {
            return db.Company.Single(x => x.Id == 1);
        }

        public List<Product> FindProductsByType(int id)
        {
            return db.Products.Where(x => x.typeId == id).ToList();
        }
    }
}
