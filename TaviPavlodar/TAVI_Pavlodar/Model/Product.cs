using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace TAVI_Pavlodar.Model
{
    public class Product
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
