using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Provider.Abstract
{
    abstract public class ProviderService
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NormalName { get; set; }
        public string Desk { get; set; }
        public string NumberForMobileConnection { get; set; }
        public float PriceForConnection { get; set; }
        public float Payment { get; set; }
        public bool IsCanConnect { get; set; }
    }
}
