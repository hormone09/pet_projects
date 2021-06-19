using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TAVI_Pavlodar.Data;
using TAVI_Pavlodar.Interfaces;
using TAVI_Pavlodar.Model;

namespace TAVI_Pavlodar.Repository
{
    public class SearchRep : ISearch
    {
        private readonly AplicationDbContext db;

        public SearchRep(AplicationDbContext db)
        {
            this.db = db;
        }

        public List<Product> GetProducts(string query)
        {
            List<Product> result = new List<Product>();
            var currentArea = db.Products;
            var currentProducts = new List<Product>();
            bool IsConcurrence = false;

            currentProducts = unchecked(currentArea.Where(x => x.desk.Equals(query))).ToList();
            IsConcurrence = currentProducts != null;
            if (IsConcurrence) result.AddRange(currentProducts);

            currentProducts = FindByParametr(query);
            IsConcurrence = currentProducts != null;
            if (IsConcurrence) result.AddRange(currentProducts);

            currentProducts = unchecked(currentArea.Where(x => x.type.Equals(query))).ToList();
            IsConcurrence = currentProducts != null;
            if (IsConcurrence) result.AddRange(currentProducts);

            return result;
        }

        public List<Product> FindByParametr(string query)
        {
            List<Product> concurrences = new List<Product>();
            bool IsConcurrence = false;

            foreach(var el in db.Products)
            {
                IsConcurrence = el.parametr1.Contains(query);
                if (!IsConcurrence)
                {
                    IsConcurrence = el.parametr2.Contains(query);
                }
                if (IsConcurrence)
                    concurrences.Add(el);
            }

            return concurrences;
        }

        public ProductType GetProductType(string query)
        {
            var result = (db.Types.Single(x => x.name.Equals(query)
            || x.normalName.Equals(query)));

            return result;
        }

        public string GetSinonim(string query)
        {
            string result = query.ToLower();
            char[] charAr = result.ToCharArray();
            charAr[0] = char.ToUpper(charAr[0]);

            for (int i =0; i<charAr.Length; i++)
            {
                if (!charAr[charAr.Length-1].Equals(' '))
                {
                    if (charAr[i].Equals(' '))
                        charAr[i + 1] = char.ToUpper(charAr[i + 1]);
                }
                    
            }
            result = "";
            foreach (var el in charAr)
                result += el;

            string[][] sinonims = new string[][]
            {
                new string[] { "LDSP", "ЛДСП", "Ламинат", "Дерево", "Древо"},
                new string[] { "Матрац", "matrac", "матрас", "Матрасы", "Матрас"},
                new string[] { "Паралон", "Пеноурилетан", "Пеноуритан", "пиноуритан"},
                new string[] { "Ткань", "Tkan", "такань", "ткань", "тикань"}
            };

            for(int i=0; i<sinonims.Length; i++)
            {
                for(int j=1; j< sinonims[i].Length; j++)
                {
                    if (result.Equals(sinonims[i][j]))
                        result = sinonims[i][0];
                }
            }

            return result;
        }
    }
}
