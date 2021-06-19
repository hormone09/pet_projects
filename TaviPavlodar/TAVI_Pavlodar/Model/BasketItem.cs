using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TAVI_Pavlodar.Model
{
    public class BasketItem
    {
        public int id { get; set; }

        public string type { get; set; }

        public int typeId { get; set; }
        public string desk { get; set; }

        public double price { get; set; }

        public double amount { get; set; }

        public string BasketId { get; set; }
    }

}
