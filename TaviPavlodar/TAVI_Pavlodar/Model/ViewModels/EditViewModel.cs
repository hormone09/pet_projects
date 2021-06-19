using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TAVI_Pavlodar.Data;

namespace TAVI_Pavlodar.Model.ViewModels
{
    public class TypeWithProducts
    {
        public ProductType type = new ProductType();

        public List<Product> CurrentProducts = new List<Product>();
    }

    public class EditViewModel
    {
        private readonly AplicationDbContext db;

        public List<TypeWithProducts> types = new List<TypeWithProducts>();

        public Product currentProduct { get; set; }

        public EditViewModel(AplicationDbContext db)
        {
            this.db = db; 
            
            foreach (ProductType el in db.Types)
            {
                TypeWithProducts type = new TypeWithProducts { type = el };
                type.CurrentProducts.AddRange(db.Products.Where(x => x.typeId == el.id));
                types.Add(type);
            }
        }
    }

    public class ProductEdited
    {
        public int id { get; set; }

        public string type { get; set; }

        public string desk { get; set; }

        public string parametr1 { get; set; }

        public string parametr2 { get; set; }

        public double price { get; set; }

        public double avalib { get; set; }

        public int typeId { get; set; }
    }
}
