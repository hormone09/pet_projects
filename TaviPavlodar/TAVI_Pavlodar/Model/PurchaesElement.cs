using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TAVI_Pavlodar.Model
{
    public class PurchaesElement
    {
        [Key]
        public string id { get; set; }

        public string name { get; set; }

        public double amount { get; set; }

        public double price { get; set; }

        public int PurchaesNumber { get; set; }
    }
}
