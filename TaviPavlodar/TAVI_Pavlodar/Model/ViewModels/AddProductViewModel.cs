using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TAVI_Pavlodar.Model.ViewModels
{
    public class AddProductViewModel
    {
        public int id { get; set; }

        public string type { get; set; }

        public string desk { get; set; }

        public string parametr1 { get; set; }

        public string parametr2 { get; set; }

        public double price { get; set; }

        public double avalib { get; set; }

        public int typeId { get; set; }

        public string TypeName { get; set; }
    }
}
