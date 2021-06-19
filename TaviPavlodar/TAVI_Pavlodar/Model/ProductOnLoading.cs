using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TAVI_Pavlodar.Model
{
    public class ProductOnLoading
    {
        public int id { get; set; }
        public string typeName { get; set; }
        public string desk { get; set; }
        public double amount {get; set;}
        public Loading loading { get; set; }

    }
}
