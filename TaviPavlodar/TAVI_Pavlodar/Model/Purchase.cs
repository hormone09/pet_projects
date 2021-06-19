using System;
using System.Collections.Generic;
using TAVI_Pavlodar.Data;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TAVI_Pavlodar.Model
{
    public class Purchase
    {
        [Key]
        public int id { get; set; }

        public string nameOfClient { get; set; }

        public DateTime timeOfPurchaes { get; set; }

        public string userId { get; set; }

        public double finalyPrice { get; set; }

        public string Status { get; set; }

        public List<PurchaesElement> purchaesElements { get; set; }

    }

}
